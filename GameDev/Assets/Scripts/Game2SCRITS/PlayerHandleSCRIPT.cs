using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandleSCRIPT : MonoBehaviour
{
    bool isAlive = true;
    public bool canDie = true;
    public float timeBetweenMove = 0.5f;
    public float speedOfMove = 0.05f;
    public float sizeOfMove = 0.1f;
    public float delayBeforeFirstMove = 2f;

    Vector3 curPosition;
    Vector3 newPosition;

    bool isMoving = false;

    int screenWidth = Screen.width;

    void Awake()
    {
#if !UNITY_EDITOR
        isAlive = true;
#endif
    }

    void Start()
    {
        StartCoroutine(PlayerHandler());
    }

    IEnumerator PlayerHandler()
    {
        yield return new WaitForSeconds(delayBeforeFirstMove);
        Game2ManagerSCRIPT.Instance.isGameStarted = true;

        Transform lastTileTransform = Physics2D.Raycast(transform.position, Vector3.back * 10f).transform;

        while (isAlive)
        {
            curPosition = transform.position;
            newPosition = transform.position + transform.up;

            isMoving = true;
            while (transform.position != newPosition)
            {
                transform.position = (transform.position + transform.up * sizeOfMove).Round(1);
                yield return new WaitForSeconds(speedOfMove);
            }
            isMoving = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back * 10f);
#if UNITY_EDITOR
            if (!canDie)
            {
                if(hit)
                {
                    hit.transform.GetComponent<SpriteRenderer>().color = Color.grey;
                    Destroy(lastTileTransform.gameObject, 0.1f);
                    TileMapBuilderSCRIPT.Instance.ChangePathCurLengthBy(-1);
                    lastTileTransform = hit.transform;
                }
                yield return new WaitForSeconds(timeBetweenMove);
                continue;
            }
#endif
            if (hit.collider == null)
            {
                isAlive = false;
                Debug.Log("You died!");
                Game2ManagerSCRIPT.Instance.DieHandler();
            }
            else
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.grey;
                Destroy(lastTileTransform.gameObject, 0.1f);
                TileMapBuilderSCRIPT.Instance.ChangePathCurLengthBy(-1);
                lastTileTransform = hit.transform;
            }

            yield return new WaitForSeconds(timeBetweenMove);
        }
    }

    Vector3 LEFTROTATION = new Vector3(0, 0, 90);
    Vector3 RIGHTROTATION = new Vector3(0, 0, -90);
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Vector2 clickPosition = Input.mousePosition;

            if (clickPosition.x < screenWidth / 2)
            {
                if (transform.eulerAngles != LEFTROTATION) transform.eulerAngles += LEFTROTATION;
                Debug.Log("Повернули налево");
            }
            else
            {
                if (transform.eulerAngles != RIGHTROTATION) transform.eulerAngles += RIGHTROTATION;
                Debug.Log("Повернули направо");
            }
        }
    }
}
