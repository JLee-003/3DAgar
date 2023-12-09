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
            //Debug.Log(direction);
        }
        rb.velocity = direction * speed;
    }
}
