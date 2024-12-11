using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public static class ImageLoader
{
    public static void GetSpriteFromUrl(string spriteUrl, Component objSprite)
    {
        string decodedUrl = DecodeUrl(spriteUrl);
        CoroutineManagerSCRIPT.Instance.Run(GetTexture(decodedUrl, objSprite));
    }
    static IEnumerator GetTexture(string url, Component objSprite)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Ошибка загрузки изображения: {www.error}");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
            if (objSprite is SpriteRenderer componentSpriteRenderer){componentSpriteRenderer.color = Color.white; componentSpriteRenderer.sprite = sprite;}
            else if (objSprite is Image componentImage) {componentImage.color = Color.white; componentImage.sprite = sprite;}
            else Debug.Log($"Я незнаю что это за компонент у объекта {objSprite}. Укажи Мне!");
        }
    }

    static string DecodeUrl(string url)
    {
        if (url.Contains("imgurl="))
        {
            string[] parts = url.Split(new string[] { "imgurl=" }, System.StringSplitOptions.None);
            string encodedUrl = parts[1].Split('&')[0];
            return UnityWebRequest.UnEscapeURL(encodedUrl);
        }
        return url;
    }
}
