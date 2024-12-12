using UnityEngine;
using UnityEngine.UI;

public class LostPanelManager : MonoBehaviour
{
    public Image backGround;
    Image lostPanel;
   

    private void Start()
    {
        lostPanel = GetComponent<Image>();
        lostPanel.color = backGround.color;
    }


}
