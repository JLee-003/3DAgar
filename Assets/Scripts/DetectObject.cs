using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour
{
    public bool foundPellet = false;
    public Vector3 direction;
    public AgarCharacter agar;
    public SphereCollider detectCollider;
    float defaultRadius = 1.25f;
    public float findingSpeed = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (!foundPellet)
        {
            Pellet p = other.GetComponent<Pellet>();
            AgarCharacter a = other.GetComponent<AgarCharacter>();
            if (p != null && a == null)
            {
                //Vector3 pPosition = new Vector3(p.GetComponent<Transform>().x, p.GetComponent<Transform>().y, p.GetComponent<Transform>().z);
                Vector3 pPosition = p.transform.position;
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
        }   
        if (!foundPellet)
        {
            direction = Vector3.zero;
            detectCollider.radius += .25f * Time.deltaTime * findingSpeed;
        }

    }
}
