using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstGameManager : MonoBehaviour
{
    public static FirstGameManager instance;
    [SerializeField] private GameObject gameOverPanel, pressToStartText;
    public bool isGameOver = false;
    [SerializeField] private BoxCollider2D playerCollider;
    public int score, record;
    [SerializeField] private TextMeshProUGUI scoreText, recordText, afterGameScore;
    PlayerColorSwitcher player;

    private void Awake()
    {
        instance = this;
        scoreText.text = "Счет: " + score.ToString("0");
        player = FindAnyObjectByType<PlayerColorSwitcher>();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Счет: " + score.ToString("0");
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressToStartText.SetActive(false);
        }
    }

    public void GameOver()
    {
        playerCollider.enabled = false;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        afterGameScore.text = "Ваш счет\n" + score.ToString("0");
        SoundManager.Instance.PlaySFX("loss");
    }

    public void Restart()
    {
        Debug.Log("Saving PlayerPrefs before restart");
        PlayerPrefs.SetInt("PlayerColor", player.isBlack ? 1 : 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
