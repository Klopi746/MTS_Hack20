using UnityEngine;

public class StartConfig : MonoBehaviour
{
    public GameObject startedConfigPanel;
    private GameConfigsRepository repo = new GameConfigsRepository();
    ConfigButton configButton;
    MainPageManager mainPageManager;

    private void Awake()
    {
        mainPageManager = FindAnyObjectByType<MainPageManager>();
    }

    private void Start()
    {
        configButton = GetComponentInParent<ConfigButton>();
    }


    public void OnButtonClick()
    {
       
        Debug.Log("HUI");
        StartCoroutine(repo.SetCurrentActiveConfig(configButton.id, HandleSuccess, (obj) => Debug.Log(obj)));

    }
    public void HandleSuccess(DefaultResponse response)
    {
        Debug.Log("HUI");
        mainPageManager.Refresh();
        mainPageManager.SpawnConfigs();
        //startedConfigPanel.SetActive(config.active);
    }

    public void StartActivePanel(bool active) 
    {
        startedConfigPanel.SetActive(active);
    }

}
