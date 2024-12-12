using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MainPageManager : MonoBehaviour
{

    private List<GameObject> spawnedObjects = new List<GameObject>();

    [SerializeField]
    private GameObject prefabToSpawn; // Префаб, который нужно спаунить.

    [SerializeField]
    private Transform parentObject; // Родительский объект для создания префаба.

    StartConfig startConfigButton;

    GameConfigsRepository repository = new GameConfigsRepository();
    /// <summary>
    /// Переход на указанную сцену.
    /// </summary>
    /// <param name="sceneName">Имя сцены для загрузки.</param>
    public void LoadScene(string sceneName)
    {
        // Проверка существования сцены перед загрузкой
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Сцена с именем '{sceneName}' не существует. Проверьте название.");
        }
    }

    private void Awake()
    {
        StartCoroutine(repository.GetConfigs<object>(HandleSuccess, (obj) => Debug.Log(obj)));
    }


    public void SpawnConfigs()
    {
        StartCoroutine(repository.GetConfigs<object>(HandleSuccess, (obj) => Debug.Log(obj)));
    }

    public void Refresh()
    {
        // Удаляем все ранее созданные объекты
        foreach (GameObject spawnedObject in spawnedObjects)
        {
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }
        }

        // Очищаем список
        spawnedObjects.Clear();
    }

    public void HandleSuccess(List<ConfigurationOut<object>> configs)
    {
        // Проверяем, есть ли конфигурации
        if (configs != null && configs.Count > 0)
        {
            foreach (var config in configs)
            {
                // Инстанцируем префаб для каждой конфигурации
                GameObject spawnedObject = Instantiate(prefabToSpawn, parentObject);

                // Добавляем объект в список
                spawnedObjects.Add(spawnedObject);

                ConfigButton configButton = spawnedObject.GetComponent<ConfigButton>();
                // Находим текстовые поля для отображения информации
                TextMeshProUGUI gameNameText = spawnedObject.transform.Find("GameNameText").GetComponent<TextMeshProUGUI>();
                TextMeshProUGUI descriptionText = spawnedObject.transform.Find("DescriptionText").GetComponent<TextMeshProUGUI>();

                // Заполняем текст в текстовых полях
                if (gameNameText != null)
                {
                    gameNameText.text = config.title; // Название игры
                }

                if (descriptionText != null)
                {
                    descriptionText.text = config.game_type; // Тип игры
                }

                configButton.id = config.id;
                StartConfig configPanel = spawnedObject.GetComponentInChildren<StartConfig>();

                if (configPanel != null)
                {
                    configPanel.StartActivePanel(config.active); // Используем активность из конфигурации
                }
                else
                {
                    Debug.LogWarning("StartConfig не найден в созданном префабе.");
                }
            }
        }
        else
        {
            // Обработка случая, когда нет конфигураций
            Debug.Log("Нет доступных конфигураций.");
        }
    }
}

