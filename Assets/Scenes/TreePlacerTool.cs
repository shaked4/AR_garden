using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantPlacer : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject flowerPrefab;
    private GameObject prefabToPlace;

    public Button treeButton;
    public Button flowerButton;

    public float minDistance = 0.5f;

    void Start()
    {
        prefabToPlace = treePrefab;
        treeButton.onClick.AddListener(() => prefabToPlace = treePrefab);
        flowerButton.onClick.AddListener(() => prefabToPlace = flowerPrefab);
    }

    void Update()
    {
        // Prevent placement if pointer is over UI
        if (Input.GetMouseButtonDown(0) && prefabToPlace != null && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Vector3 spawnPosition = hit.point + Vector3.up * (prefabToPlace.transform.localScale.y / 2);
                Instantiate(prefabToPlace, spawnPosition, Quaternion.identity);
            }
        }
    }
}
    


