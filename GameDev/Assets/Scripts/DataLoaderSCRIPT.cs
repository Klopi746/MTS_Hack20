using System;
using System.Collections;
using System.Collections.Generic;
using SerializableDictionary.Scripts;
using UnityEngine;
using UnityEngine.Networking;

public class DataLoaderSCRIPT : MonoBehaviour
{
    public static DataLoaderSCRIPT Instance;
    public SerializableDictionary<string, int> spritesToDownload = new SerializableDictionary<string, int>();


    void Awake()
    {
        Instance = this;
    }

    public void SendData()
    {
        StartCoroutine(CreateConfig());
    }
    public IEnumerator CreateConfig()
    {
        var dataDictionary = spritesToDownload;
        string configJson = JsonUtility.ToJson(dataDictionary);
        Debug.Log(configJson);
        using (UnityWebRequest request = new UnityWebRequest("https://venum-games.ru/api/v1/games/configs", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(configJson);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string response = JsonUtility.FromJson<string>(request.downloadHandler.text);
                Debug.Log($"Config created! ID: {response}");
            }
            else
            {
                Debug.LogError($"Error creating config: {request.error}");
            }
        }
    }
}
