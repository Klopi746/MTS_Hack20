using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerHandleSCRIPT : MonoBehaviour
{
    public static PlayerHandleSCRIPT Instance;

    bool isAlive = true;
    public bool canDie = true;
    public float timeBetweenMove = 0.5f;
    public float rateOfSaveTimeDecrease = 200f;
    public float speedOfMove = 0.01f;
    public float sizeOfMove = 0.02f;
    public float delayBeforeFirstMove = 2f;

    Vector3 curPosition;
    Vector3 newPosition;

    public bool isMoving = false;

    public Vector2 pointerPos;
    int screenWidth = Screen.width;

    void Awake()
    {
        Instance = this;
#if !UNITY_EDITOR
        isAlive = true;
#endif
    }

    void Start()
    {
        InputAction pointAction = InputSystem.actions.FindAction("Point");
        pointAction.performed += context => { pointerPos = context.ReadValue<Vector2>(); };
        StartCoroutine(PlayerHandler());
    }

    IEnumerator PlayerHandler()
    {
        while (Game2ManagerSCRIPT.Instance.isGameStarted == false) yield return null;

        yield return new WaitForSeconds(delayBeforeFirstMove);

        Transform lastTileTransform = Physics2D.Raycast(transform.position, Vector3.back * 10f).transform;

        while (isAlive)
        {
            curPosition = transform.position;
            newPosition = curPosition + transform.up;

            isMoving = true;
            while (transform.position != newPosition)
            {
                transform.position = (transform.position + transform.up * sizeOfMove).Round(2);
                yield return new WaitForSeconds(speedOfMove);
            }
            isMoving = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back * 10f);
#if UNITY_EDITOR
            if (!canDie)
            {
                if (hit)
                {
                    hit.transform.GetComponent<SpriteRenderer>().color = Color.grey;
                    Destroy(lastTileTransform.gameObject, 0.1f);
                    TileMapBuilderSCRIPT.Instance.ChangePathCurLengthBy(-1);
                    Game2ManagerSCRIPT.Instance.AddScore(1);
                    Game2ManagerSCRIPT.Instance.UpdateCoinsText();
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
                StopCoroutine("PlayerHandler");
            }
            else
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.grey;
                Destroy(lastTileTransform.gameObject, 0.1f);
                TileMapBuilderSCRIPT.Instance.ChangePathCurLengthBy(-1);
                Game2ManagerSCRIPT.Instance.AddScore(1);
                Game2ManagerSCRIPT.Instance.UpdateCoinsText();
                lastTileTransform = hit.transform;
            }

            yield return new WaitForSeconds(timeBetweenMove);
            timeBetweenMove -= Game2ManagerSCRIPT.Instance.GetScore() / rateOfSaveTimeDecrease;
        }
    }

    Vector3 LEFTROTATION = new Vector3(0, 0, 90);
    Vector3 RIGHTROTATION = new Vector3(0, 0, 90);
    public void OnClickAction(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (context.performed && !isMoving)
        {
            if (pointerPos.x < screenWidth / 2)
            {
                if (transform.eulerAngles != LEFTROTATION) transform.eulerAngles += LEFTROTATION;
                Debug.Log("Повернули налево");
            }
            else
            {
                if (transform.eulerAngles.Round(0) != RIGHTROTATION * 3) transform.eulerAngles += -RIGHTROTATION;
                Debug.Log("Повернули направо");
            }
        }
    }
}
