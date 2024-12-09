using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2ManagerSCRIPT : MonoBehaviour
{
    public static Game2ManagerSCRIPT Instance;

    public bool isGameStarted = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    public void DieHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
