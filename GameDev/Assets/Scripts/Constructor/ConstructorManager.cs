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


        selectedObject = newObject;
        Debug.Log($"Выбран объект: {selectedObject.name}");


        SpriteRenderer currentRenderer = selectedObject.GetComponent<SpriteRenderer>();
        if (currentRenderer != null)
        {
            Color color = currentRenderer.color;
            color.a = 0.6f; 
            currentRenderer.color = color;
        }
    }

    public void ChangeColor(string hexColor)
    {
        if (selectedObject != null)
        {
            if (ColorUtility.TryParseHtmlString(hexColor, out Color color))
            {
                SpriteRenderer spriteRenderer = selectedObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = color;
                    Debug.Log($"Цвет объекта {selectedObject.name} изменен на {color}");
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
