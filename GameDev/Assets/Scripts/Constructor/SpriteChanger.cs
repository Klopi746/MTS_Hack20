using UnityEngine;
using UnityEngine.UI;

public class SpriteChangeButton : MonoBehaviour
{
    public Sprite newSprite; // Спрайт, задаваемый в инспекторе
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError($"На объекте {gameObject.name} отсутствует компонент Button!");
        }
    }

    private void OnButtonClick()
    {
        ConstructorManager constructorManager = FindAnyObjectByType<ConstructorManager>();
        if (constructorManager != null)
        {
            constructorManager.ChangeSprite(newSprite);
        }
        else
        {
            Debug.LogError("ConstructorManager не найден на сцене!");
        }
    }

    public void SetTransparency(float alpha)
    {
        MaskableGraphic graphic = GetComponent<MaskableGraphic>(); // Для работы с UI графикой
        if (graphic != null)
        {
            Color color = graphic.color;
            color.a = alpha; // Устанавливаем прозрачность
            graphic.color = color;
        }
        else
        {
            Debug.LogWarning($"На объекте {gameObject.name} отсутствует MaskableGraphic для работы с прозрачностью!");
        }
    }
}
