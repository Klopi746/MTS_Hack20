using System.Collections;
using UnityEngine;

public class TileSCRIPT : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DecreasePlayerPathIfBeForgotten());
    }

    IEnumerator DecreasePlayerPathIfBeForgotten()
    {
        yield return new WaitForSeconds(TileMapBuilderSCRIPT.Instance.PATHCONSTLENGTH + 1f);
        Game2ManagerSCRIPT.Instance.tilesUnPainted += 1;
    }

    public void Die()
    {
        StopAllCoroutines();
        Destroy(transform.gameObject, 0.1f);
    }
}
