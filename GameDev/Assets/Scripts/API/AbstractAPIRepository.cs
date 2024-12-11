using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Unity.VisualScripting;


public abstract class AbstractAPIRepository 
{
    public IEnumerator GetRequest<ResponseModel>(string uri, Action<ResponseModel> onSuccessCallback, Action<String> onErrorCallback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
                onErrorCallback(request.error);
            }
            else
            {
                Debug.Log("Successfuly requested");

                var text = request.downloadHandler.text;
                Debug.Log(text);

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(text);
                onSuccessCallback(responseData);
            }
        }
    }

    public IEnumerator PostRequest<ResponseModel>(string uri, object data, String contentType, Action<ResponseModel> onSuccessCallback, Action<String> onErrorCallback)
    {
        if (!data.GetType().IsSerializable)
        {
            throw new ArgumentException("The data passed is not serializable and therefore is not valid.", "data");
        }

        string serializedData = JsonConvert.SerializeObject(data);

        using (UnityWebRequest request = UnityWebRequest.Post(uri, serializedData, contentType))
        {
            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
                onErrorCallback(request.error);
            }
            else
            {
                Debug.Log("Successfuly requested");

                var text = request.downloadHandler.text;
                Debug.Log(text);

                ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(text);
                onSuccessCallback(responseData);
            }
        }
    }

    public IEnumerator PatchRequest<ResponseModel>(string uri, object data, Action<ResponseModel> onSuccessCallback, Action<String> onErrorCallback)
    {
        if (!data.GetType().IsSerializable)
        {
            throw new ArgumentException("The data passed is not serializable and therefore is not valid.", nameof(data));
        }

        string serializedData = JsonConvert.SerializeObject(data);

        using (UnityWebRequest request = UnityWebRequest.Put(uri, serializedData))
        {
            request.method = "PATCH";

            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.LogError(request.error);
                onErrorCallback(request.error);
            }
            else
            {
                Debug.Log("Successfully requested");

                var text = request.downloadHandler.text;
                Debug.Log($"Response text: {text}");

                try
                {
                    ResponseModel responseData = JsonConvert.DeserializeObject<ResponseModel>(text);
                    onSuccessCallback(responseData);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Deserialization error: {e.Message}");
                    onErrorCallback("Deserialization failed.");
                }
            }
        }
    }
}