using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConstructorManager : MonoBehaviour
{
    private GameObject selectedObject;
    private Color originalColor;
    private ColorChangeButton previousButton;

    [Header("Effect Spawn Settings")]
    public Transform effectSpawnPoint;

    public int vfxIndex = -1;


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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePosition, Vector2.zero);

            // Если объектов, пересекающих луч, несколько
            if (hits.Length > 0)
            {
                // Сортируем объекты по расстоянию (для правильного выбора переднего)
                RaycastHit2D closestHit = hits.OrderBy(hit => hit.distance).FirstOrDefault();

                if (closestHit.collider != null)
                {
                    SelectObject(closestHit.collider.gameObject);
                }
            }
        }
    }

    private void SelectObject(GameObject newObject)
    {
        // Если объект не выбран, ничего не делаем
        if (newObject == null)
        {
            DeselectCurrentObject();
            return;
        }

        // Снятие выделения с текущего объекта
        DeselectCurrentObject();

        // Назначение нового выбранного объекта
        selectedObject = newObject;
        Debug.Log($"Выбран объект: {selectedObject.name}");

        // Снижение прозрачности нового выбранного объекта
        Image currentRenderer = selectedObject.GetComponent<Image>();
        if (currentRenderer != null)
        {
            Color color = currentRenderer.color;
            color.a = 0.6f;
            currentRenderer.color = color;
        }

    }

    private void DeselectCurrentObject()
    {
        if (selectedObject != null)
        {
            Image previousRenderer = selectedObject.GetComponent<Image>();
            if (previousRenderer != null)
            {
                Color color = previousRenderer.color;
                color.a = 1f;
                previousRenderer.color = color;
            }
        }

        selectedObject = null;
    }

    public void ChangeColor(string hexColor, ColorChangeButton buttonScript)
    {
        if (selectedObject != null)
        {
            if (ColorUtility.TryParseHtmlString(hexColor, out Color color))
            {
                Image spriteRenderer = selectedObject.GetComponent<Image>();
                if (spriteRenderer != null)
                {
                    if (spriteRenderer.color == color)
                    {
                        // Сброс цвета
                        spriteRenderer.color = originalColor;
                        buttonScript.SetTransparency(1f); // Восстановить прозрачность кнопки
                        Debug.Log($"Цвет объекта {selectedObject.name} сброшен на {originalColor}");
                    }
                    else
                    {
                        // Сохранение оригинального цвета и установка нового
                        originalColor = spriteRenderer.color;
                        spriteRenderer.color = color;
                        buttonScript.SetTransparency(0.6f); // Уменьшить прозрачность кнопки
                        Debug.Log($"Цвет объекта {selectedObject.name} изменен на {color}");

                        // Снятие выделения с объекта
                        SelectObject(null);
                    }
                }
                else
                {
                    Debug.LogWarning("Выбранный объект не имеет SpriteRenderer!");
                }
            }
            else
            {
                Debug.LogError("Некорректный формат цвета в HEX!");
            }
        }
        else
        {
            Debug.LogWarning("Объект для изменения цвета не выбран!");
        }

        // Сброс прозрачности предыдущей кнопки
        if (previousButton != null && previousButton != buttonScript)
        {
            previousButton.SetTransparency(1f);
        }

        // Установка текущей кнопки как предыдущей
        previousButton = buttonScript;
    }

    public void ResetAll()
    {
        if (selectedObject != null)
        {
            Image spriteRenderer = selectedObject.GetComponent<Image>();
            if (spriteRenderer != null)
            {
                // Восстановление оригинального цвета
                spriteRenderer.color = Color.white;
                
                // Восстановить полную непрозрачность объекта
                Color color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;
                Debug.Log($"Цвет объекта {selectedObject.name} сброшен на оригинальный: {originalColor}");
            }
            else
            {
                Debug.LogWarning("Выбранный объект не имеет SpriteRenderer!");
            }
        }
        else
        {
            Debug.LogWarning("Объект для сброса цвета не выбран!");
        }

        // Снять выделение с объекта
        SelectObject(null);
    }


    public void ChangeSprite(Sprite newSprite)
    {
        if (selectedObject != null)
        {
            Image spriteRenderer = selectedObject.GetComponent<Image>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
                Debug.Log($"Спрайт объекта {selectedObject.name} изменен на {newSprite.name}");

                // Восстановление прозрачности объекта
                Color color = spriteRenderer.color;
                color.a = 1f; // Устанавливаем полную непрозрачность
                spriteRenderer.color = color;
            }
            else
            {
                Debug.LogWarning("Выбранный объект не имеет SpriteRenderer!");
            }
        }
        else
        {
            Debug.LogWarning("Объект для изменения спрайта не выбран!");
        }
    }





    public void SpawnEffect(GameObject effectPrefab)
    {
        if (effectPrefab != null && effectSpawnPoint != null)
        {
            Instantiate(effectPrefab, effectSpawnPoint.position, Quaternion.identity);
            Debug.Log($"Эффект {effectPrefab.name} заспаунен в точке {effectSpawnPoint.position} с индексом {vfxIndex}");
        }
        else
        {
            Debug.LogError("Префаб эффекта или точка спауна не установлены!");
        }
    }

    public void SetEffectIndex(int index)
    {
        vfxIndex = index;
    }
}
