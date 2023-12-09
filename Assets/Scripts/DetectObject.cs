using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public bool foundPellet = false;
    public Vector3 direction;
    public AgarCharacter agar;
    public SphereCollider detectCollider;
    public float defaultRadius = 1.25f;
    Pellet p;
    AgarCharacter a;
    Vector3 pPosition;
    Vector3 aPosition;
    Vector3 aVelocity;
    public float findingSpeed = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (!foundPellet)
        {
            p = other.GetComponent<Pellet>();
            //a = other.GetComponent<AgarCharacter>();
            if (p != null)
            {
                //Vector3 pPosition = new Vector3(p.GetComponent<Transform>().x, p.GetComponent<Transform>().y, p.GetComponent<Transform>().z);
                pPosition = p.transform.position;
                Vector3 position = this.transform.position;
                direction = pPosition - position;
                direction.Normalize();
                foundPellet = true;
                detectCollider.radius = defaultRadius;
            }
        }
    }

    public void Start()
    {
        detectCollider = GetComponent<SphereCollider>();
        detectCollider.radius = defaultRadius;
    }
    public void Update()
    {
        if (agar.Eaten)
        {
            foundPellet = false;
            agar.Eaten = false;
            p = null;
        }
        if (!foundPellet)
        {
            direction = Vector3.zero;
            detectCollider.radius += .25f * Time.deltaTime * findingSpeed;
        }
        if (foundPellet && p != null)
        {
            if (pPosition != p.transform.position)
            {
                foundPellet = false;
                p = null;
            }
        }
    }
}
