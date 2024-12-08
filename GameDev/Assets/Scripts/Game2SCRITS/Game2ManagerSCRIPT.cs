using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2ManagerSCRIPT : MonoBehaviour
{
    public static Game2ManagerSCRIPT Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    public void DieHandler()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
