using UnityEngine;

public class SimplePlacer : MonoBehaviour
{
    public GameObject prefabToPlace;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
