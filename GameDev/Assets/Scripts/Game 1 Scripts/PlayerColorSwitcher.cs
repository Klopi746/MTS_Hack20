using UnityEngine;

public class PlayerColorSwitcher : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public bool isBlack = false;
    Animator anim;


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
        SetColor(isBlack ? Color.black : Color.white);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Clicked");

            isBlack = !isBlack;
            SetColor(isBlack ? Color.black : Color.white);
            PlayerPrefs.SetInt("PlayerColor", isBlack ? 1 : 0); 
        }
    }

    private void SetColor(Color color)
    {
        if (spriteRenderer.material.HasProperty("_Color"))
        {
            spriteRenderer.material.SetColor("_Color", color);
        }
    }
}
