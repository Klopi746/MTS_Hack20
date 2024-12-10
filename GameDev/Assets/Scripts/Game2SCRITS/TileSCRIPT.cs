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
        yield return new WaitForSeconds(TileMapBuilderSCRIPT.Instance.PATHCONSTLENGTH + 3f);
        Game2ManagerSCRIPT.Instance.tilesUnPainted += 1;
    }

    public void Die()
    {
        StopAllCoroutines();
        StopCoroutine(DecreasePlayerPathIfBeForgotten());
        Destroy(transform.gameObject, 0.1f);
    }
}
