using UnityEngine;

public class TileMapBuilderSCRIPT : MonoBehaviour
{
    public static TileMapBuilderSCRIPT Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] GameObject tilePrefab;

    public int PATHCONSTLENGTH = 10;

    enum NextGenerationDirection
    {
        forward,
        left,
        right
    }

    const NextGenerationDirection fwd = NextGenerationDirection.forward;
    const NextGenerationDirection lft = NextGenerationDirection.left;
    const NextGenerationDirection rgt = NextGenerationDirection.right;

    Vector3 GetVector3FromDirection(NextGenerationDirection direction = fwd)
    {
        switch (direction)
        {
            case fwd:
                return new Vector3(0, 1, 0);
            case lft:
                return new Vector3(-1, 0, 0);
            case rgt:
                return new Vector3(1, 0, 0);
            default:
                return Vector3.up;
        }
    }

    private Vector3 tileLastPos;
    void GenerateTile(NextGenerationDirection direction = fwd)
    {
        Vector3 tilePos = tileLastPos + GetVector3FromDirection(direction);
        RaycastHit2D hit = Physics2D.Raycast(tilePos + new Vector3(0, 0, -0.05f), Vector3.back * 1f);
        if (!hit || hit.transform.gameObject.layer != 3) // Ground
        {
            Instantiate(tilePrefab, tilePos, Quaternion.identity);
            tileLastPos = tilePos;
        }
    }

    public int pathCurLength;
    public void ChangePathCurLengthBy(int value = -1)
    {
        pathCurLength += value;
    }
    void HandlePath()
    {
        if (pathCurLength < PATHCONSTLENGTH)
        {
            NextGenerationDirection dirFromRandom = (NextGenerationDirection)Random.Range(0, 3);
            GenerateTile(dirFromRandom);
            pathCurLength += 1;
        }
    }

    void Start()
    {
        pathCurLength = PATHCONSTLENGTH;

        tileLastPos = transform.position;

        for (int i = 0; i < PATHCONSTLENGTH; i++)
        {
            GenerateTile();
        }

    }

    void Update()
    {
        if (Game2ManagerSCRIPT.Instance.isGameStarted) HandlePath();
    }
}
