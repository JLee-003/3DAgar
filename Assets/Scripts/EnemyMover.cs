using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 5f;
    internal Rigidbody rb;
    public SphereCollider detectCollider;
    public DetectObject Dto;
    public bool foundPellet = false;
    public BoxCollider containedVolume;
    Vector3 direction;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        direction = Dto.direction;
        //direction = HitWall(direction);
        Move(direction);
    }
    public void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            Debug.Log(direction);
        }
        rb.velocity = direction * speed;
    }
    public Vector3 HitWall(Vector3 direction)
    {
        float x = this.transform.position.x;
        float y = this.transform.position.z;
        float xBound = containedVolume.size.x / 2;
        float yBound = containedVolume.size.z / 2;
        Vector3 d = direction;
        if (x > xBound || x < -xBound)
        {
            if (x > xBound)
            {
                x = xBound;
            }
            if (x < -xBound)
            {
                x = -xBound;
            }
            d.x = -d.x;
        }
        if (y > yBound || y < -yBound)
        {
            if (y > yBound)
            {
                y = yBound;
            }
            if (y < -yBound)
            {
                y = -yBound;
            }
            d.z = -d.z;
        }
        this.transform.position = new Vector3(x, this.transform.position.y, y);
        return d;
    }
}
