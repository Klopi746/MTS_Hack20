using UnityEngine;

public class PlayerColorSwitcher : MonoBehaviour
{
    [HideInInspector] public bool isBlack = false;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    

    void Start()
    {
        spriteRenderer.color = Color.white;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Clicked");
            if (isBlack)
            {
                spriteRenderer.color = Color.white;
                Debug.Log("Игрок стал белым");
            }
            else
            {
                spriteRenderer.color = Color.black;
                Debug.Log("Игрок стал черным");
            }

            isBlack = !isBlack;
        }
    }
}
