using System.CodeDom.Compiler;
using NUnit.Framework.Constraints;
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
    bool GenerateTile(NextGenerationDirection direction = fwd)
    {
        bool isGenerated = false;

        Vector3 tilePos = tileLastPos + GetVector3FromDirection(direction);
        RaycastHit2D hit = Physics2D.Raycast(tilePos + new Vector3(0, 0, -0.05f), Vector3.back * 1f);
        if (!hit || hit.transform.gameObject.layer != 3) // Ground
        {
            Instantiate(tilePrefab, tilePos, Quaternion.identity);
            tileLastPos = tilePos;
            isGenerated = true;
            return isGenerated;
        }
        isGenerated = false;
        return isGenerated;
    }

    public int tilesSpawned;
    public void ChangeTilesSpawnedBy(int value = -1)
    {
        tilesSpawned += value;
    }
    void HandlePath()
    {
        if (!isGenerateFirstTile)
        {
            for (int i = 0; i < pathStartLength; i++)
            {
                GenerateTile();
            }
            isGenerateFirstTile = true;
        }
        if (PATHCONSTLENGTH - Game2ManagerSCRIPT.Instance.tilesUnPainted < Game2ManagerSCRIPT.Instance.STOPTILEGENERATIONAFTERPATHLENGTHLESSTHAN)
        {
            return;
        }
        if (tilesSpawned <= PATHCONSTLENGTH)
        {
            NextGenerationDirection dirFromRandom = (NextGenerationDirection)Random.Range(0, 3);
            if (GenerateTile(dirFromRandom)) tilesSpawned += 1;
        }
    }

    public int pathStartLength = 6;
    public bool isGenerateFirstTile = false;
    void Start()
    {
        tilesSpawned = pathStartLength;

        tileLastPos = transform.position;
    }

    void Update()
    {
        if (Game2ManagerSCRIPT.Instance.isGameStarted) HandlePath();
    }
}
