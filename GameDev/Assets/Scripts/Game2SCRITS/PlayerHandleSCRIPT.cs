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

    bool isMoving = false;

    int screenWidth = Screen.width;

    void Start()
    {
        StartCoroutine(PlayerHandler());
    }

    IEnumerator PlayerHandler()
    {
        yield return new WaitForSeconds(delayBeforeFirstMove);
        while (isAlive)
        {
            curPosition = transform.position;
            newPosition = transform.position + transform.up;
            isMoving = true;
            while (transform.position != newPosition)
            {
                transform.position = (transform.position + transform.up * speedOfMove).Round(1);
                yield return new WaitForSeconds(speedOfMove);
            }
            isMoving = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back * 10f);
            if (hit.collider == null)
            {
                isAlive = false;
                Debug.Log("You died!");
                Game2ManagerSCRIPT.Instance.DieHandler();
            }
            yield return new WaitForSeconds(timeBetweenMove);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Vector2 clickPosition = Input.mousePosition;

            if (clickPosition.x < screenWidth / 2)
            {
                Debug.Log("Повернули налево");
                transform.eulerAngles += new Vector3(0, 0, -90);
            }
            else
            {
                Debug.Log("Повернули напрво");
                transform.eulerAngles += new Vector3(0, 0, -90);
            }
        }
    }
}
