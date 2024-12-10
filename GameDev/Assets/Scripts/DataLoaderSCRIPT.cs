using System;
using SerializableDictionary.Scripts;
using UnityEngine;

public class DataLoaderSCRIPT : MonoBehaviour
{
    public static DataLoaderSCRIPT Instance;
    public SerializableDictionary<string, SpriteRenderer> SpritesToDownload = new SerializableDictionary<string, SpriteRenderer>();

    void Awake()
    {
        Instance = this;
    }
}