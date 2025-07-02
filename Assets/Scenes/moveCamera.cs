using UnityEngine;

public class FreeFlyCamera : MonoBehaviour
{
    public float lookSpeed = 2.0f;
    public float moveSpeed = 5.0f;
    public float fastMoveSpeed = 10.0f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        if (Input.GetMouseButton(1))  // רק אם קליק ימני לחוץ - מסתובבים
    {
        HandleMouseLook();
        Cursor.lockState = CursorLockMode.Locked;
    }
    else
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // תנועה עם WASD תמידית, בלי קשר ללחיצה
    HandleMovement();
    }

    void HandleMouseLook()
    {
        if (Input.GetMouseButton(1)) // לחיצה על קליק ימני
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            rotationX -= mouseY;
            rotationY += mouseX;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void HandleMovement()
    {
       

        float speed = Input.GetKey(KeyCode.LeftShift) ? fastMoveSpeed : moveSpeed;

        Vector3 move = new Vector3(
            Input.GetAxis("Horizontal"),  // A/D
            0f,
            Input.GetAxis("Vertical")     // W/S
        );

        // תזוזה יחסית לכיוון המצלמה
        transform.Translate(move * speed * Time.deltaTime, Space.Self);
    }
}
