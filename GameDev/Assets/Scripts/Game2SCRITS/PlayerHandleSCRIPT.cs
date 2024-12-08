using System;
using System.Collections;
using UnityEngine;

public class PlayerHandleSCRIPT : MonoBehaviour
{
    bool isAlive = true;
    public float timeBetweenMove = 0.5f;
    public float speedOfMove = 0.1f;
    public float delayBeforeFirstMove = 2f;

    Vector3 curPosition;
    Vector3 newPosition;

    void Start()
    {
        StartCoroutine(PlayerHandler());
    }

    IEnumerator PlayerHandler()
    {
        yield return new WaitForSeconds(delayBeforeFirstMove);
        while(isAlive)
        {
            curPosition = transform.position;
            newPosition = transform.position + transform.up;
            while(transform.position != newPosition)
            {
                transform.position = (transform.position + transform.up * speedOfMove).Round(1);
                yield return new WaitForSeconds(speedOfMove);
            }
            yield return new WaitForSeconds(timeBetweenMove);
        }
    }
}
