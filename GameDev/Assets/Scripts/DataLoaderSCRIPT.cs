using System;
using System.Collections;
using System.Collections.Generic;
using SerializableDictionary.Scripts;
using UnityEngine;
using UnityEngine.Analytics;

public class DataLoaderSCRIPT : MonoBehaviour
{
    public static DataLoaderSCRIPT Instance;
    public MonoBehaviour SetDataSCRIPT;
    public bool isDataImporter = true;
    public string GameName = "ColorSwitch";
    public Dictionary<string, string> DataToUse = new Dictionary<string, string>();

    void Awake()
    {
        Instance = this;
        if (isDataImporter) GetData();
    }

    GameConfigsRepository config = new GameConfigsRepository();
    public void GetData()
    {
        StartCoroutine(LoadConfig());
    }
    IEnumerator LoadConfig()
    {
        if (GameName == "CubeRun")
        {
            yield return config.GetCurrentActiveConfig<PathOfHeroAttributesOut>(GameName,
                config =>
            {
                Debug.Log($"Configs loaded: {config}");
                SetPathOfHeroData(config);
            },
                error =>
            {
                Debug.LogError($"Error loading configs: {error}");
            }
            );
        }
        else
        {
            yield return config.GetCurrentActiveConfig<BallsOfFateAttributesOut>(GameName,
                config =>
            {
                Debug.Log($"Configs loaded: {config}");
                SetBallsOfFateData(config);
            },
                error =>
            {
                Debug.LogError($"Error loading configs: {error}");
            }
            );
        }
    }
    void SetBallsOfFateData(ConfigurationOut<BallsOfFateAttributesOut> config)
    {
        var keys = typeof(BallsOfFateAttributesOut).GetFields();
        var attributes = config.configuration;
        foreach(var key in keys)
        {
            var value = key.GetValue(attributes);
            if (value == null) continue;
            var valueStr = value.ToString();
            Debug.Log(key.Name + ":" + valueStr);
            DataToUse.Add(key.Name, valueStr);
        }
        // string name = config.configuration.backgroundSprite;
        // DataToUse.Add(name, name);
        SetDataSCRIPT.Invoke("SetData", 0f);
    }

    void SetPathOfHeroData(ConfigurationOut<PathOfHeroAttributesOut> config)
    {
        var keys = typeof(PathOfHeroAttributesOut).GetFields();
        var attributes = config.configuration;
        foreach(var key in keys)
        {
            var value = key.GetValue(attributes);
            if (value == null) continue;
            var valueStr = value.ToString();
            Debug.Log(key.Name + ":" + valueStr);
            DataToUse.Add(key.Name, valueStr);
        }
        // string name = config.configuration.backgroundSprite;
        // DataToUse.Add(name, name);
        SetDataSCRIPT.Invoke("SetData", 0f);
    }


    public void SendData()
    {
        StartCoroutine(CreateConfig());
    }
    public IEnumerator CreateConfig()
    {
        yield return null;
    }
}
