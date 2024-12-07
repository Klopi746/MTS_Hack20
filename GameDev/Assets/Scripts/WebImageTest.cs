using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class WebImageTest : MonoBehaviour
{
    public Image uiImage;
    void Start()
    {
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://i.pinimg.com/originals/18/49/5f/18495fc57202045db3299834b4e27759.jpg");
        www.SetRequestHeader("mode", "no-cors");
        www.SetRequestHeader("Access-Control-Allow-Credentials", "true");
        www.SetRequestHeader("Access-Control-Allow-Headers", "Accept, X-Access-Token, X-Application-Name, X-Request-Sent-Time");
        www.SetRequestHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
        www.SetRequestHeader("Access-Control-Allow-Origin", "*");
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
}
