using UnityEngine;
using UnityEngine.UI;

public class ColorChangeButton : MonoBehaviour
{
    public string hexColor; // HEX цвет, задаваемый в инспекторе
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
            constructorManager.ChangeColor(hexColor, this);
        }
        else
        {
            Debug.LogError("ConstructorManager не найден на сцене!");
        }
    }

    public void SetTransparency(float alpha)
    {
        MaskableGraphic svgGraphic = GetComponent<MaskableGraphic>(); // Для работы с SVG
        if (svgGraphic != null)
        {
            Color color = svgGraphic.color;
            color.a = alpha; // Устанавливаем прозрачность
            svgGraphic.color = color;
        }
        else
        {
            Debug.LogWarning($"На объекте {gameObject.name} отсутствует MaskableGraphic для работы с прозрачностью!");
        }
    }
}
