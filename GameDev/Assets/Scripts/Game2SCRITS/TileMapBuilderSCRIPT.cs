using UnityEngine;

public class TileMapBuilderSCRIPT : MonoBehaviour
{
    [SerializeField] GameObject tilePrefab;

    public int pathConstLength = 10;

    private Vector3 tileLastPos;

    enum NextGenerationDirection
    {
        forward,
        left,
        right
    }

    const NextGenerationDirection fwd = NextGenerationDirection.forward;
    const NextGenerationDirection lft = NextGenerationDirection.left;
    const NextGenerationDirection rgt = NextGenerationDirection.right;

    void GenerateTile(NextGenerationDirection direction = fwd)
    {
        Vector3 tilePos = tileLastPos + GetVector3FromDirection(direction);
        Instantiate(tilePrefab, tilePos, Quaternion.identity);
        tileLastPos = tilePos;
    }

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

    void Start()
    {
        tileLastPos = transform.position;

        for (int i = 0; i < pathConstLength; i++)
        {
            GenerateTile();
        }
    }

    void Update()
    {

    }

    void HandlePath()
    {

    }
}
