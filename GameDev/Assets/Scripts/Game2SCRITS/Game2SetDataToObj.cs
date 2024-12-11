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
                string url = DataLoaderSCRIPT.Instance.DataToUse[kvp.Key];
                if (isStringUrlSCRIPT.IsUrl(url))
                {
                    SpriteRenderer spriteRendererComponent = kvp.Value.GetComponent<SpriteRenderer>();
                    ImageLoader.GetSpriteFromUrl(url, spriteRendererComponent);
                }
            }
            if (kvp.Key.Contains("Color", StringComparison.OrdinalIgnoreCase))
            {
                string colorString = DataLoaderSCRIPT.Instance.DataToUse[kvp.Key];
                byte r = Convert.ToByte(colorString.Substring(0, 2), 16); // Красный
                byte g = Convert.ToByte(colorString.Substring(2, 2), 16); // Зеленый
                byte b = Convert.ToByte(colorString.Substring(4, 2), 16); // Синий
                kvp.Value.GetComponent<SpriteRenderer>().color = new Color(r,g,b);
            }
        }
    }
}
