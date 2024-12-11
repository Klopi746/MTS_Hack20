using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using SerializableDictionary.Scripts;
using UnityEngine.InputSystem;
using System;
using System.Resources;

public class Game2SetDataToObj : MonoBehaviour
{
    public SerializableDictionary<string, GameObject> DataToSet = new SerializableDictionary<string, GameObject>();
    public void SetData()
    {
        foreach(System.Collections.Generic.KeyValuePair<string, GameObject> kvp in DataToSet.Dictionary)
        {
            if (!DataLoaderSCRIPT.Instance.DataToUse.ContainsKey(kvp.Key)) continue;
            if (kvp.Key.Contains("Sprite", StringComparison.OrdinalIgnoreCase))
            {
                string url = DataLoaderSCRIPT.Instance.DataToUse.Dictionary[kvp.Key];
                if (isStringUrlSCRIPT.IsUrl(url))
                {
                    SpriteRenderer spriteRendererComponent = kvp.Value.GetComponent<SpriteRenderer>();
                    ImageLoader.GetSpriteFromUrl(url, spriteRendererComponent);
                }
            }
            if (kvp.Key.Contains("Color", StringComparison.OrdinalIgnoreCase))
            {
                string colorString = DataLoaderSCRIPT.Instance.DataToUse.Dictionary[kvp.Key];
                byte r = Convert.ToByte(colorString.Substring(2, 2), 16); // Красный
                byte g = Convert.ToByte(colorString.Substring(4, 2), 16); // Зеленый
                byte b = Convert.ToByte(colorString.Substring(6, 2), 16); // Синий
                kvp.Value.GetComponent<SpriteRenderer>().color = new Color(r,g,b);
            }
        }
        // Debug.Log(DataLoaderSCRIPT.Instance.DataToUse.ContainsKey(objNameToSetData));
        // var SpritesDictionary = DataLoaderSCRIPT.Instance.DataToUse;
        // Debug.Log(SpritesDictionary);
        // if (SpritesDictionary.ContainsKey(objNameToSetData))
        // {
        //     objSprite.color = Color.red;
        //     Debug.Log($"{objNameToSetData} загружена успешна!");
        // }
        // else
        // {
        //     Debug.Log($"{objNameToSetData} НЕ загружена!");
        // }
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
