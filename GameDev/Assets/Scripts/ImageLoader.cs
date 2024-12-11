using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public static class ImageLoader
{
    public static void GetSpriteFromUrl(string spriteUrl, SpriteRenderer objSprite)
    {
        string decodedUrl = DecodeUrl(spriteUrl);
        CoroutineManagerSCRIPT.Instance.Run(GetTexture(decodedUrl, objSprite));
    }
    static IEnumerator GetTexture(string url, SpriteRenderer objSprite)
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
            objSprite.sprite = sprite;
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
