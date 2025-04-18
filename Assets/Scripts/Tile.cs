using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color color = Color.green;
    [SerializeField] private GameObject highlightPrefab;

    void OnMouseEnter()
    {
        highlightPrefab.SetActive(true);
    }

    void OnMouseExit()
    {
        highlightPrefab.SetActive(false);
    }
}
