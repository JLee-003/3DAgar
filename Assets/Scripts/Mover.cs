using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform cameraTransform;
    public BoxCollider worldSize;
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
        float topExtent = worldSize.transform.position.y + worldSize.size.y / 2;
        float bottomExtent = worldSize.transform.position.y - worldSize.size.y / 2;
        float leftExtent = worldSize.transform.position.x - worldSize.size.x / 2;
        float rightExtent = worldSize.transform.position.x + worldSize.size.x / 2;
        float frontExtent = worldSize.transform.position.z + worldSize.size.z / 2;
        float backExtent = worldSize.transform.position.z - worldSize.size.z / 2;

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
        if (transform.position.y > topExtent || transform.position.y < bottomExtent)
        {
            direction.y = 0;
            if (transform.position.y > topExtent)
            {
                transform.position = new Vector3(transform.position.x, topExtent, transform.position.z);
            }
            if (transform.position.y < bottomExtent)
            {
                transform.position = new Vector3(transform.position.x, bottomExtent, transform.position.z);
            }
        }
        if (transform.position.x > rightExtent || transform.position.x < leftExtent)
        {
            direction.x = 0;
            if (transform.position.x > rightExtent)
            {
                transform.position = new Vector3(rightExtent, transform.position.y, transform.position.z);
            }
            if (transform.position.x < leftExtent)
            {
                transform.position = new Vector3(leftExtent, transform.position.y, transform.position.z);
            }
        }
        if (transform.position.z > frontExtent || transform.position.z < backExtent)
        {
            direction.z = 0;
            if (transform.position.z > frontExtent)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, frontExtent);
            }
            if (transform.position.z < backExtent)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, backExtent);
            }
        }
        rb.velocity = direction * speed;
    }
}
