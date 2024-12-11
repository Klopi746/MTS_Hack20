using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Unity.VisualScripting;



public class GameConfigsRepository: AbstractAPIRepository
{
    

    private const String BASEURL = "https://venum-games.ru/api";

    public IEnumerator GetConfigs<Attributes>(Action<List<ConfigurationOut<Attributes>>> onSuccessCallback, Action<String> onErrorCallback) {
        yield return GetRequest(BASEURL + "/v1/games/configs", onSuccessCallback, onErrorCallback);
    }

    public IEnumerator CreateConfig<Attributes>(ConfigurationCreate<Attributes> newConfig, Action<CreateConfigurationResult> onSuccessCallback, Action<String> onErrorCallback) {
        yield return PostRequest(BASEURL + "/v1/games/configs", newConfig, "application/json", onSuccessCallback, onErrorCallback);
    }

    public IEnumerator UpdateConfig<Attributes>(String configId, ConfigurationUpdate<Attributes> data, Action<CreateConfigurationResult> onSuccessCallback, Action<String> onErrorCallback) {
        // onSuccessCallback return always null, i create response model later
        yield return PatchRequest(BASEURL + "/v1/games/configs/" + configId, data, onSuccessCallback, onErrorCallback);
    }
}


// StartCoroutine call only from MonoBehaviour

// Get Configs Example
//StartCoroutine(repository.GetConfigs<BallsOfFateAttributesOut>((obj) => Debug.Log(obj), (message) => Debug.Log(message)));


// Create Config Example
//BallsOfFateAttributesCreate newAtributes = new BallsOfFateAttributesCreate("#FFF");
//ConfigurationCreate<BallsOfFateAttributesCreate> newConfig = new ConfigurationCreate<BallsOfFateAttributesCreate>(newAtributes);
//StartCoroutine(repository.CreateConfig(newConfig, (obj) => Debug.Log(obj), (message) => Debug.Log(message)));

// Example Update Config
//BallsOfFateAttributesUpdate updatedAtributes = new BallsOfFateAttributesUpdate("HUI");
//ConfigurationUpdate<BallsOfFateAttributesUpdate> updatedConfig = new ConfigurationUpdate<BallsOfFateAttributesUpdate>(updatedAtributes);
//StartCoroutine(repository.UpdateConfig("6758ba18aa709b5edeac4c93", updatedConfig, (obj) => Debug.Log(obj), (message) => Debug.Log(message)));

// In onSuccessCallback and onErrorCallback you can pass anyone methods that have similar signature
