using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

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
    [SerializeField] private GameObject makeGreyParticles;

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

        transform.rotation = Quaternion.identity;

        startTimeBetweenMove = timeBetweenMove;
        StartCoroutine(PlayerHandler());
    }

    public bool canRotate = false;
    private float startTimeBetweenMove;
    public int difficulty = 10;
    public void UpdateDifficulty()
    {
        difficulty = DifficultySCRIPT.Instance.difficulty;
    }
    IEnumerator PlayerHandler()
    {
        while (Game2ManagerSCRIPT.Instance.isGameStarted == false) yield return null;

        yield return new WaitForSeconds(delayBeforeFirstMove);

        Transform lastTileTransform = Physics2D.Raycast(transform.position, Vector3.back * 10f).transform;

        canRotate = true;

        while (isAlive)
        {
            curPosition = transform.position;
            newPosition = curPosition + transform.up;

            isMoving = true;
            while (transform.position != newPosition)
            {
                transform.position = (transform.position + transform.up * sizeOfMove).Round(2);
                yield return new WaitForSeconds(speedOfMove - Game2ManagerSCRIPT.Instance.GetScore() * (difficulty / 100000));
            }
            isMoving = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.back * 10f);
#if UNITY_EDITOR
            if (!canDie)
            {
                if (hit)
                {
                    hit.transform.GetComponent<SpriteRenderer>().color = Color.grey;
                    Instantiate(makeGreyParticles, transform.position, Quaternion.identity);
                    SoundManager.Instance.PlaySFX("miniMagic");

                    lastTileTransform.GetComponent<TileSCRIPT>().Die();

                    TileMapBuilderSCRIPT.Instance.ChangeTilesSpawnedBy(-1);

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
                Instantiate(makeGreyParticles, transform.position, Quaternion.identity);
                SoundManager.Instance.PlaySFX("miniMagic");

                lastTileTransform.GetComponent<TileSCRIPT>().Die();

                TileMapBuilderSCRIPT.Instance.ChangeTilesSpawnedBy(-1);

                Game2ManagerSCRIPT.Instance.AddScore(1);
                Game2ManagerSCRIPT.Instance.UpdateCoinsText();

                lastTileTransform = hit.transform;
            }

            yield return new WaitForSeconds(timeBetweenMove);
            timeBetweenMove -= Game2ManagerSCRIPT.Instance.GetScore() / rateOfSaveTimeDecrease;

            while (isRotating)
            {
                yield return null;
            }
        }
    }

    Vector3 LEFTROTATION = new Vector3(0, 0, 90);
    Vector3 RIGHTROTATION = new Vector3(0, 0, 90);
    public float sizeOfCamRotaion = 0.01f;
    public float slowlinessOfCamRotation = 0.01f;
    public bool isRotating = false;

    public void Rotate(bool dir)
    {
        if (!canRotate) return;
        if (isRotating) return;
        if (isMoving) return;
        isRotating = true;
        StopCoroutine("RotateBy");
        if (!dir)
        {
            StartCoroutine(RotateBy(false));
        }
        else
        {
            StartCoroutine(RotateBy(true));
        }
    }
    // public void OnClickAction(InputAction.CallbackContext context)
    // {
    //     if (EventSystem.current.IsPointerOverGameObject()) return;
    //     if (!canRotate) return;
    //     if (isRotating) return;
    //     if (context.performed && !isMoving)
    //     {
    //         pointerPos = context.ReadValue<Vector2>();
    //         isRotating = true;
    //         StopCoroutine("RotateBy");
    //         if (pointerPos.x < screenWidth / 2)
    //         {
    //             StartCoroutine(RotateBy(false));
    //         }
    //         else
    //         {
    //             StartCoroutine(RotateBy(true));
    //         }
    //     }
    // }
    IEnumerator RotateBy(bool rotatedir = true)
    {
        Vector3 endRotationVector;
        float curRotation;
        Vector3 curRotationVector;
        isRotating = true;
        if (!rotatedir) // LEFT
        {
            endRotationVector = transform.eulerAngles + LEFTROTATION;
        }
        else // RIGHT
        {
            endRotationVector = transform.eulerAngles - RIGHTROTATION;
        }
        curRotation = 0;
        while (curRotation < 90)
        {
            curRotation += sizeOfCamRotaion;
            curRotationVector = new(0, 0, sizeOfCamRotaion);
            if (rotatedir)
            {
                transform.eulerAngles -= curRotationVector;
            }
            else
            {
                transform.eulerAngles += curRotationVector;
            }
            yield return new WaitForSeconds(slowlinessOfCamRotation);
        }
        transform.eulerAngles = endRotationVector;
        isRotating = false;
    }
}
