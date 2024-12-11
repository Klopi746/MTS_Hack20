using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySCRIPT : MonoBehaviour
{
    public static DifficultySCRIPT Instance;
    void Awake()
    {
        Instance = this;
    }
    public int difficulty = 1;
    public void SetDifficulty(int value)
    {
        difficulty = value;
        string currentSceneName = SceneManager.GetActiveScene().name;
        switch(currentSceneName)
        {
            case "CubeRunGame2":
            PlayerHandleSCRIPT.Instance.UpdateDifficulty();
            break;
            case "ColorSwitch Game 1":
            BallSpawner.Instance.UpdateDifficulty();
            break;
        }
    }
}
