using UnityEngine;
using SerializableDictionary.Scripts;
using System;
using UnityEngine.UI;

public class GameSetDataToObj : MonoBehaviour
{
    public SerializableDictionary<string, GameObject> DataToSet = new SerializableDictionary<string, GameObject>();
    public void SetData()
    {
        foreach (System.Collections.Generic.KeyValuePair<string, GameObject> kvp in DataToSet.Dictionary)
        {
            if (!DataLoaderSCRIPT.Instance.DataToUse.ContainsKey(kvp.Key)) continue;
            if (kvp.Key.Contains("Sprite", StringComparison.OrdinalIgnoreCase))
            {
                string url = DataLoaderSCRIPT.Instance.DataToUse[kvp.Key];
                if (isStringUrlSCRIPT.IsUrl(url))
                {
                    SpriteRenderer spriteRendererComponent = kvp.Value.GetComponent<SpriteRenderer>();
                    Image spriteImageComponent = kvp.Value.GetComponent<Image>();
                    if (spriteRendererComponent != null) ImageLoader.GetSpriteFromUrl(url, spriteRendererComponent);
                    else ImageLoader.GetSpriteFromUrl(url, spriteImageComponent);
                }
            }
            if (kvp.Key.Contains("Color", StringComparison.OrdinalIgnoreCase))
            {
                string colorString = DataLoaderSCRIPT.Instance.DataToUse[kvp.Key];
                byte r = Convert.ToByte(colorString.Substring(0, 2), 16); // Красный
                byte g = Convert.ToByte(colorString.Substring(2, 2), 16); // Зеленый
                byte b = Convert.ToByte(colorString.Substring(4, 2), 16); // Синий
                Color newColor = new Color(r, g, b);
                if (kvp.Key.Contains("platformColorFirst", StringComparison.OrdinalIgnoreCase))
                {
                    newColor = new Color(r, g, b, 0f);
                }
                else if (kvp.Key.Contains("platformColorSecond", StringComparison.OrdinalIgnoreCase))
                {
                    newColor = new Color(r, g, b, 0f);
                }
                SpriteRenderer colorRendererComponent = kvp.Value.GetComponent<SpriteRenderer>();
                Image colorImageComponent = kvp.Value.GetComponent<Image>();
                ParticleSystem colorParticalSystem = kvp.Value.GetComponent<ParticleSystem>();
                if (colorRendererComponent != null) colorRendererComponent.color = newColor;
                else if (colorImageComponent) colorImageComponent.color = newColor;
                else if (colorParticalSystem) colorParticalSystem.startColor = newColor;
                else Debug.Log($"Я незнаю что это за компонент у объекта {kvp.Value}. Укажи Мне!");
            }
            if (kvp.Key.Contains("difficulty", StringComparison.OrdinalIgnoreCase))
            {
                DifficultySCRIPT.Instance.SetDifficulty(Convert.ToInt32(DataLoaderSCRIPT.Instance.DataToUse[kvp.Key]));
            }
        }
    }
}
