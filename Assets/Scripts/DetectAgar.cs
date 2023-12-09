using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAgar : MonoBehaviour
{
    //public bool foundPellet = false;
    public bool foundAgar = false;
    public Vector3 direction;
    public AgarCharacter agar;
    public SphereCollider detectCollider;
    float defaultRadius = 1.25f;
    //Pellet p;
    AgarCharacter a;
    //Vector3 pPosition;
    Vector3 aPosition;
    Vector3 aVelocity;
    public float findingSpeed = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (!foundAgar)
        {
            a = other.GetComponent<AgarCharacter>();
            //a = other.GetComponent<AgarCharacter>();
            if (a != null)
            {
                //Vector3 pPosition = new Vector3(p.GetComponent<Transform>().x, p.GetComponent<Transform>().y, p.GetComponent<Transform>().z);
                foundAgar = true;
                detectCollider.radius = defaultRadius;
            }
        }
    }
    private void MoveDirection()
    {
        aPosition = a.transform.position;
        Vector3 position = this.transform.position;
        direction = aPosition - position;
        direction.Normalize();
        if (agar.Radius < a.Radius)
        {
            direction *= -1;
        }
    }
    public void Start()
    {
        detectCollider = GetComponent<SphereCollider>();
        detectCollider.radius = defaultRadius;
    }
    public void Update()
    {
        if (!foundAgar)
        {
            detectCollider.radius += .25f * Time.deltaTime * findingSpeed;
            if(detectCollider.radius > 50)
            {
                detectCollider.radius = defaultRadius;
            }
        }
        if (foundAgar && a != null)
        {
            MoveDirection();
            float dist = Vector3.Distance(a.transform.position, agar.transform.position);
            if (dist > 50)
            {
                foundAgar = false;
                a = null;
            }
        }
    }
}
