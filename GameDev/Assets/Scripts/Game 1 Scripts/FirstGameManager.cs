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
    [SerializeField] private int score, record;
    [SerializeField] private TextMeshProUGUI scoreText, recordText, afterGameScore;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
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
            Time.timeScale = 1;
            pressToStartText.SetActive(false);
        }
    }

    public void GameOver()
    {
        playerCollider.enabled = false;
        isGameOver = true;
        gameOverPanel.SetActive(true);
        afterGameScore.text = "Ваш счет\n" + score.ToString("0");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
