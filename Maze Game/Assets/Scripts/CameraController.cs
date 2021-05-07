using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camRotation = 1f;
    public Transform Player, Target;
    float mouseX, mouseY;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject cam = GameObject.FindWithTag("Camera");
        cam.GetComponent<CameraController>().enabled = false;
    }

    private void LateUpdate()
    {
        
        CamControl();
       
    }

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * camRotation;
        mouseY -= Input.GetAxis("Mouse Y") * camRotation;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        Player.rotation = Quaternion.Euler(0f, mouseX, 0f);
    }

    

}
