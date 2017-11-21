using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100.0F;
    public float movementSpeed = 5.0F;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float z = Input.GetAxis("Vertical") * movementSpeed;
        float x = Input.GetAxis("Horizontal") * rotationSpeed;
        x *= Time.deltaTime;
        z *= Time.deltaTime;

        transform.Translate(0, 0, z);
        transform.Rotate(0, x, 0);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}