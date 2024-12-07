using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ImageLoader : MonoBehaviour
{
    public Image uiImage;
    public string imageUrl;

    void Start()
    {
        string decodedUrl = DecodeUrl(imageUrl);
        StartCoroutine(GetTexture(decodedUrl));
    }

    IEnumerator GetTexture(string url)
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
            uiImage.sprite = sprite;
        }
    }

    string DecodeUrl(string url)
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
