using UnityEngine;

public class GridManager: MonoBehaviour {
    [SerializeField] private Tile tilePrefab;

    [SerializeField] private Transform cam;

    private int width = Constants.grid_width, height = Constants.grid_height;
    
    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Tile tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                tile.name = $"Tile {x} {y}";
            }
        }

        cam.position = new Vector3(width / 2f - .5f, height / 2f - .5f);
    }
}
