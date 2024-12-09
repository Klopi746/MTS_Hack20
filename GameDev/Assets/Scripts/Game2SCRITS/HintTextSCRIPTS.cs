using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintTextSCRIPTS : MonoBehaviour
{
    public TextMeshProUGUI textObj;

    public List<string> texts = new List<string>()
    {
        "Tap here!", // start text
        "<color=#ff0000ff>Tap</color>", // can't tap if moving
        "<color=#00ff00ff>Tap</color>" // tap on stop
    };

    void Update()
    {
        if (!Game2ManagerSCRIPT.Instance.isGameStarted) textObj.text = texts[0];
        else if (PlayerHandleSCRIPT.Instance.isMoving) textObj.text = texts[1];
        else if (!PlayerHandleSCRIPT.Instance.isMoving) textObj.text = texts[2];
    }
}
