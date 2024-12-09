using UnityEngine;
using UnityEngine.UI;

public class ConstructorManager : MonoBehaviour
{
    private GameObject selectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
                Debug.Log($"Выбран объект: {selectedObject.name}");
            }
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
}
