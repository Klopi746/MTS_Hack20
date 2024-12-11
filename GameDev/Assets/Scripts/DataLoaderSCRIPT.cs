using System;
using System.Collections;
using SerializableDictionary.Scripts;
using UnityEngine;

public class DataLoaderSCRIPT : MonoBehaviour
{
    public static DataLoaderSCRIPT Instance;
    public MonoBehaviour SetDataSCRIPT;
    public bool isDataImporter = true;
    public SerializableDictionary<string, string> DataToUse = new SerializableDictionary<string, string>();

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
        yield return config.GetConfigs<BallsOfFateAttributesOut>(configs =>
        {
            Debug.Log($"Configs loaded: {configs.Count}");
            if (configs.Count < 1) {Debug.LogWarning("There is no Configs!"); return;}
            SetData(configs[0]);
        },
            error =>
        {
            Debug.LogError($"Error loading configs: {error}");
        }
        );
    }
    void SetData(ConfigurationOut<BallsOfFateAttributesOut> config)
    {
        var keys = typeof(BallsOfFateAttributesOut).GetFields();
        var attributes = config.configuration;
        foreach(var key in keys)
        {
            var value = key.GetValue(attributes).ToString();
            DataToUse.Add(key.Name, key.GetValue(attributes).ToString());
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
