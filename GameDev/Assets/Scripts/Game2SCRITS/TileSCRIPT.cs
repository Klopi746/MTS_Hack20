using System.Collections;
using UnityEngine;

public class TileSCRIPT : MonoBehaviour
{
    [SerializeField] private GameObject destroyParticles;
    [SerializeField] private float tileSmoothDieSpeed = 10;
    void Start()
    {
        StartCoroutine(DecreasePlayerPathIfBeForgotten());
    }

    IEnumerator DecreasePlayerPathIfBeForgotten()
    {
        yield return new WaitForSeconds(TileMapBuilderSCRIPT.Instance.PATHCONSTLENGTH * 2);
        Game2ManagerSCRIPT.Instance.tilesUnPainted += 1;
    }

    public void Die()
    {
        StopAllCoroutines();
        StopCoroutine(DecreasePlayerPathIfBeForgotten());
        StartCoroutine(DieSmoothly());
    }

    IEnumerator DieSmoothly()
    {
        while(transform.localScale.x > 0.1f)
        {
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime * tileSmoothDieSpeed);
        }
        SoundManager.Instance.PlaySFX("enemyDestroy");
        Instantiate(destroyParticles, transform.position, Quaternion.identity);
        Destroy(transform.gameObject, 0.1f);
    }
}
