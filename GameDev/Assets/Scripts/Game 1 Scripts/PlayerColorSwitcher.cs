using UnityEngine;

public class PlayerColorSwitcher : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isBlack = false;
    Animator anim;
    public SpriteRenderer firstColor;
    public SpriteRenderer secondColor;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        isBlack = PlayerPrefs.GetInt("PlayerColor", 0) == 1;
        Debug.Log($"PlayerPrefs loaded. isBlack: {isBlack}");
        SetColor(isBlack ? firstColor.color : secondColor.color);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Clicked");

            isBlack = !isBlack;
            SetColor(isBlack ? firstColor.color : secondColor.color);
            PlayerPrefs.SetInt("PlayerColor", isBlack ? 1 : 0);
        }
    }

    private void SetColor(Color color)
    {
        // Получаем только RGB компоненты (игнорируем альфу)
        Color colorWithoutAlpha = new Color(color.r, color.g, color.b, 1f);

        if (spriteRenderer.material.HasProperty("_Color"))
        {
            spriteRenderer.material.SetColor("_Color", colorWithoutAlpha);
        }
    }
}