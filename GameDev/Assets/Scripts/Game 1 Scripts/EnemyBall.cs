using UnityEngine;

public class EnemyBall : MonoBehaviour
{
    public bool isBlack = false;
    PlayerColorSwitcher player;
    public float speed = 2f;


    private void Awake()
    {
        player = FindAnyObjectByType<PlayerColorSwitcher>();
    }


    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isBlack == player.isBlack)
            {
                FirstGameManager.instance.AddScore();
                Destroy(this.gameObject);
            }
            else
            {
                FirstGameManager.instance.GameOver();
                Destroy(this.gameObject);
            }
        }
    }
}
