using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100.0F;
    public float movementSpeed = 5.0F;
    const float minY = -75.0f;
    const float maxY = 75.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float z = Input.GetAxis("Vertical") * movementSpeed;
        float x = Input.GetAxis("Horizontal") * movementSpeed;
        float mouseY = Input.GetAxis("MouseY") * rotationSpeed;
        float mouseX = Input.GetAxis("MouseX") * rotationSpeed;

        x *= Time.deltaTime;
        z *= Time.deltaTime;

        mouseX *= Time.deltaTime;
        mouseY *= Time.deltaTime;

        mouseX += transform.rotation.eulerAngles.y;
        mouseY += transform.rotation.eulerAngles.x;

        mouseY = (mouseY > 180) ? mouseY - 360: mouseY;
        mouseY = Mathf.Clamp(mouseY, minY, maxY);

        transform.Translate(x, 0, z);
        transform.rotation = Quaternion.identity * Quaternion.AngleAxis(mouseX, Vector3.up) * Quaternion.AngleAxis(mouseY, Vector3.right);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}