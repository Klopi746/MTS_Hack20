using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseTemplateManager : MonoBehaviour
{
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
}
