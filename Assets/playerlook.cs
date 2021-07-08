using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlook : MonoBehaviour
{
    [SerializeField] private string Xinput, Yinput;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform PlayerBody;

    private float xclamp;

    private void Awake() {
        cursorlock();
        xclamp = 0.0f;
    }


    private void cursorlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        cameraRotation();
    }
    private void cameraRotation(){
        float mouseX = Input.GetAxis(Xinput) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(Yinput) * mouseSensitivity * Time.deltaTime;

        xclamp += mouseY;

        if(xclamp > 90.0f)
        {
            xclamp = 90.0f;
            mouseY = 0.0f;
            xclampValue(270.0f);
        }
        else if(xclamp < -90.0f)
        {
            xclamp = -90.0f;
            mouseY = 0.0f;
            xclampValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
    private void xclampValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
