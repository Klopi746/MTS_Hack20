using UnityEngine;
using UnityEngine.UI;

public class ConstructorManager : MonoBehaviour
{
    private GameObject selectedObject;
    private Color originalColor;

    [Header("Effect Spawn Settings")]
    public Transform effectSpawnPoint;

    public int vfxIndex = -1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                SelectObject(hit.collider.gameObject);
            }
        }
    }

    private void SelectObject(GameObject newObject)
    {
        // Восстановление прозрачности предыдущего объекта
        if (selectedObject != null)
        {
            SpriteRenderer previousRenderer = selectedObject.GetComponent<SpriteRenderer>();
            if (previousRenderer != null)
            {
                Color color = previousRenderer.color;
                color.a = 1f;
                previousRenderer.color = color;
            }
        }

        // Назначение нового выбранного объекта
        selectedObject = newObject;
        Debug.Log($"Выбран объект: {selectedObject.name}");

        // Снижение прозрачности нового выбранного объекта
        SpriteRenderer currentRenderer = selectedObject.GetComponent<SpriteRenderer>();
        if (currentRenderer != null)
        {
            Color color = currentRenderer.color;
            color.a = 0.6f;
            currentRenderer.color = color;
        }
    }

    public void ChangeColor(string hexColor, ColorChangeButton buttonScript)
    {
        if (selectedObject != null)
        {
            if (ColorUtility.TryParseHtmlString(hexColor, out Color color))
            {
                SpriteRenderer spriteRenderer = selectedObject.GetComponent<SpriteRenderer>();
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
    }



    private void SetButtonTransparency(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            Color color = buttonImage.color;
            color.a = 0.6f; // Уменьшение прозрачности на 40%
            buttonImage.color = color;
        }
    }

    private void ResetButtonTransparency(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            Color color = buttonImage.color;
            color.a = 1f; // Восстановление полной прозрачности
            buttonImage.color = color;
        }
    }

    public void ChangeSprite(Sprite newSprite)
    {
        if (selectedObject != null)
        {
            SpriteRenderer spriteRenderer = selectedObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
                Debug.Log($"Спрайт объекта {selectedObject.name} изменен на {newSprite.name}");
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
