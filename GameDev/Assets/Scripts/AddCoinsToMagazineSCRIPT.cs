using TMPro;
using UnityEngine;

public class AddCoinsToMagazineSCRIPT : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    void Start()
    {
        coinText.text = $"Coins: {PlayerPrefs.GetInt("Game2MtsCoins")}";
    }
}
