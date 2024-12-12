using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;

public class ConfigButton : MonoBehaviour
{
    public Button button1;
    public Button button2;
    private Color originalColor;
    private SVGImage svgImage;

    public string id;

    void Start()
    {
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        svgImage = GetComponent<SVGImage>();
        originalColor = svgImage.color;
    }

    public void OnHoverEnter()
    {
        var color = svgImage.color;
        color.a = 150f / 255f;
        svgImage.color = color;

        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
    }

    public void OnHoverExit()
    {
        svgImage.color = originalColor;
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
    }
}
