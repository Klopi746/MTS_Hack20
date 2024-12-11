using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using SerializableDictionary.Scripts;

public class Game2SetDataToObj : MonoBehaviour
{
    string objNameToSetData = "bgSprite_123";
    public SpriteRenderer objSprite;
    void Start()
    {

    }

    public void SetData()
    {
        Debug.Log(DataLoaderSCRIPT.Instance.spritesToDownload.ContainsKey(objNameToSetData));
        var SpritesDictionary = DataLoaderSCRIPT.Instance.spritesToDownload;
        Debug.Log(SpritesDictionary);
        if (SpritesDictionary.ContainsKey(objNameToSetData))
        {
            objSprite.color = Color.red;
            Debug.Log($"{objNameToSetData} загружена успешна!");
        }
        else
        {
            Debug.Log($"{objNameToSetData} НЕ загружена!");
        }
            // if (SpritesDictionary.Dictionary.TryGetValue("tile", out valueSpriteRenderer))
            // {
            //     Debug.Log($"{objNameToSetData} загружена успешна!");
            //     // Do smth with valueSpriteRenderer
            // }
            // else
            // {
            //     Debug.Log($"{objNameToSetData} НЕ загружена!");
            // }
    }
}
