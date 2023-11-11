using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float pitch, yaw;
    public float mouseSensitivty = 5f;

    private void Update()
    {
        pitch += Input.GetAxis("Mouse Y") * mouseSensitivty;
        yaw += Input.GetAxis("Mouse X") * mouseSensitivty;
        distance += Input.GetAxis("Mouse ScrollWheel");
        this.transform.rotation = Quaternion.Euler(-pitch, yaw, 0);
        this.transform.position = target.position - (this.transform.forward * distance);
    }
}
