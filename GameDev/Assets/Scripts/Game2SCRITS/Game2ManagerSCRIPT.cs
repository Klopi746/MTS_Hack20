using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game2ManagerSCRIPT : MonoBehaviour
{
    public static Game2ManagerSCRIPT Instance;

    void Awake()
    {
        Instance = this;
    }

    public bool isGameStarted = false;

    void Start()
    {
        tilesPainted = 0;
        tilesUnPainted = 0;
        PlayerPrefs.DeleteAll();
    }


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
        coinsTextObj.text = tilesPainted.ToString("0");
    }


    public void RunGame()
    {
        isGameStarted = true;
    }


    public int tilesUnPainted = 0;
    public int STOPTILEGENERATIONAFTERPATHLENGTHLESSTHAN = 5;
    public Button endGameButton;
    public TextMeshProUGUI endGameText;
    public void DieHandler()
    {
        var lastTilesPainted = PlayerPrefs.GetInt("Game2MtsCoins");
        PlayerPrefs.SetInt("Game2MtsCoins", tilesPainted > lastTilesPainted ? tilesPainted : lastTilesPainted);
        endGameText.text = tilesPainted.ToString("0");
        endGameButton.gameObject.SetActive(true);

    }




    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
