using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform cameraTransform;
    internal Rigidbody rb;
    public float horizontal, vertical;
    public float speed = 5f;
    public bool moving = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        Move(direction);
    }
    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.Normalize();
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            moving = true;
        }
        else
        {
            moving = false;
        }
        rb.velocity = direction * speed;
    }
}
