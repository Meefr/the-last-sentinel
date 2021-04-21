using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public float mouseSensitivity = 1000f;
    public Transform playerBody;
    float xRotaion = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // to hide the mouse on game * Should be change to mouse aim like games
    }

    // Update is called once per frame
    void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotaion -= mouseY;
            xRotaion = Mathf.Clamp(xRotaion, -90f, 90f); // To make sure that the view angle never goes up than 90 Degrees or less than -90 Degrees
            transform.localRotation = Quaternion.Euler(xRotaion, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
    }
}
