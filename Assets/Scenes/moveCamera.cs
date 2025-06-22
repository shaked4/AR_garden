using UnityEngine;

public class FreeCameraLook : MonoBehaviour
{
    public float lookSpeed = 4.0f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Update()
    {
        if (Input.GetMouseButton(1)) // קליק ימני לחוץ
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

            rotationX -= mouseY;
            rotationY += mouseX;

            rotationX = Mathf.Clamp(rotationX, -90f, 90f); // לא לסובב יותר מדי למעלה/למטה

            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
