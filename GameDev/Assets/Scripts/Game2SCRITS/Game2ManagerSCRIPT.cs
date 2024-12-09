using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2ManagerSCRIPT : MonoBehaviour
{
    public static Game2ManagerSCRIPT Instance;

    public bool isGameStarted = false;

    public int tilesPainted = 0;
    public int GetScore()
    {
        return tilesPainted;
    }
    public void AddScore(int value = 1)
    {
        tilesPainted += 1;
    }
    public TextMeshProUGUI coinsTextObj;
    public void UpdateCoinsText()
    {
        coinsTextObj.text = ($"Painted: {tilesPainted}");
    }

    public void RunGame()
    {
        isGameStarted = true;
    }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    public void DieHandler()
    {
        
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
