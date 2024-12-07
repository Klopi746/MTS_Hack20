using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class WebImageTest : MonoBehaviour
{
    public Image uiImage; 
    public string imageUrl = "https://example.com/your-image.png";

    private void Start()
    {
        string decodedUrl = DecodeUrl(imageUrl);
        StartCoroutine(LoadImageFromURL(decodedUrl));
    }

    private IEnumerator LoadImageFromURL(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        request.SetRequestHeader("Access-Control-Allow-Credentials", "true");
        request.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time");
        request.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        request.SetRequestHeader("Access-Control-Allow-Origin", "*");
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Ошибка загрузки изображения: {request.error}");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
            uiImage.sprite = sprite;
        }
    }

    private string DecodeUrl(string url)
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
