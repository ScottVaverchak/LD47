using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float LookSpeed = 1.0f;

    public float YClampMaxAngle;
    public float YClampMinAngle;

    public GameObject Camera;

    // Rotation
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    void Start()
    {
        

        if(Camera == null)
        {
            Debug.LogError("Player is missing eyes to look out of -_-");
            return;
        }
    }

    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * LookSpeed;
        rotY += Input.GetAxis("Mouse Y") * LookSpeed;

        rotY = Mathf.Clamp(rotY, YClampMinAngle,YClampMaxAngle);

        Camera.transform.localRotation = Quaternion.Euler(-rotY,0.0f, 0.0f);
        transform.localRotation = Quaternion.Euler(0.0f,rotX, 0.0f);

    }
}
