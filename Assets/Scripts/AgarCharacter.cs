using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarCharacter : MonoBehaviour
{
    private float radius = 0.5f;
    public SphereCollider _collider;
    public MeshRenderer _renderer;
    public SphereCollider eatingCollider;
    public float eatingExtent = 0.05f;
    public bool Eaten = false;
    public bool isEaten = false;
    public float Radius
    {
        get => radius;
        set
        {
            radius = value;
            _collider.radius = value;
            eatingCollider.radius = value + eatingExtent;
            _renderer.transform.localScale = Vector3.one * radius * 2;
        }
    }
}
