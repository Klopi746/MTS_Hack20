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
        coinsTextObj.text = ($"Painted: {tilesPainted}");
    }


    public void RunGame()
    {
        isGameStarted = true;
    }


    public int tilesUnPainted = 0;
    public int STOPTILEGENERATIONAFTERPATHLENGTHLESSTHAN = 5;
    public Button endGameButton;
    public TextMeshProUGUI endGameText;
    public string endText = "Earned 0 MtsCoins";
    public void DieHandler()
    {
        endGameText.text = ($"Earned {tilesPainted} MtsCoins");
        endGameButton.gameObject.SetActive(true);
        OfferPlayAgain();
    }
    public void OfferPlayAgain()
    {
        StartCoroutine(OfferPlayAgainCoroutine());
    }
    IEnumerator OfferPlayAgainCoroutine()
    {
        yield return new WaitForSeconds(2f);
        endGameButton.interactable = true;
        endGameText.text += "\n Tap to play again...";
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
