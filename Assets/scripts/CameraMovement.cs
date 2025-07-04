using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Movement
        float h = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float v = Input.GetAxis("Vertical");   // W/S or Up/Down
        Vector3 move = (transform.forward * v + transform.right * h) * moveSpeed * Time.deltaTime;
        transform.position += move;

        // Mouse look
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            float yaw = delta.x * lookSpeed * 0.1f;
            float pitch = -delta.y * lookSpeed * 0.1f;
            transform.eulerAngles += new Vector3(pitch, yaw, 0);
            lastMousePosition = Input.mousePosition;
        }
    }
} 