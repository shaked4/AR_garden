using UnityEngine;
using UnityEngine.UI;

public class SimplePlacer : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject flowerPrefab;
    private GameObject prefabToPlace;

    public Button treeButton;
    public Button flowerButton;

    void Start()
    {
        // ברירת מחדל - עץ
        prefabToPlace = treePrefab;

        // מאזינים לכפתורים
        treeButton.onClick.AddListener(() => prefabToPlace = treePrefab);
        flowerButton.onClick.AddListener(() => prefabToPlace = flowerPrefab);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && prefabToPlace != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Vector3 spawnPosition = hit.point + Vector3.up * (prefabToPlace.transform.localScale.y / 2);
                Instantiate(prefabToPlace, spawnPosition, Quaternion.identity);
                Debug.Log("Placed prefab at: " + hit.point);
            }
        }
    }
}
