using UnityEngine;
using UnityEngine.InputSystem;

public class GridManager: MonoBehaviour
{
    [SerializeField] private GridDetails gridDetails;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private int width, height;
    private GameObject[,] borders;

    void Awake() 
    {
        // Initialize width and height from gridDetails
        width = gridDetails.gridWidth;
        height = gridDetails.gridHeight;
        GenerateGridVertices();
    }

    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
        
        if (Mouse.current.leftButton.isPressed)
        {
            DisplayVerticesPrefab.SetActive(true);
        } else
        {
            highlightCirclePrefab.SetActive(false);
            highlightVerticesPrefab.SetActive(false);
        }
    }
    void GenerateGridVertices()
    {
        // We need width+1 by height+1 vertices for a grid
        vertices = new GameObject[gridWidth + 1, gridHeight + 1];
        
        for (int x = 0; x <= gridWidth; x++)
        {
            for (int y = 0; y <= gridHeight; y++)
            {
                // Calculate world position for this vertex
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                
                // Create vertex object
                GameObject vertex = Instantiate(vertexPrefab, position, Quaternion.identity);
                vertex.transform.parent = transform;
                vertex.name = $"Vertex_{x}_{y}";
                
                // Store reference to the vertex
                vertices[x, y] = vertex;
                
                // Initially hide the vertex
                vertex.SetActive(false);
            }
        }
    }
    void DisplayVertices()
    {

    }
    void HideVertices()
    {
        highlightCirclePrefab.SetActive(false);
        highlightVerticesPrefab.SetActive(false);
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Tile tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
            }
        }

        cam.position = new Vector3(width / 2f - .5f, height / 2f - .5f, -10f);
    }
}
