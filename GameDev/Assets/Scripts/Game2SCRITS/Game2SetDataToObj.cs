using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Game2SetDataToObj : MonoBehaviour
{
    string objNameToSetData = "tile";
    void Start()
    {
        var SpritesDictionary = DataLoaderSCRIPT.Instance.SpritesToDownload;
        if (SpritesDictionary.ContainsKey("tile"))
        {
            SpriteRenderer valueSpriteRenderer = null;
            if (SpritesDictionary.Dictionary.TryGetValue("tile", out valueSpriteRenderer))
            {
                Debug.Log($"{objNameToSetData} загружена успешна!");
                // Do smth with valueSpriteRenderer
            }
            else
            {
                Debug.Log($"{objNameToSetData} НЕ загружена!");
            }
        }
    }
}
