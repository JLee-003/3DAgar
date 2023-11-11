using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eater : MonoBehaviour
{
    public AgarCharacter agar;
    private void OnTriggerEnter(Collider other)
    {
        Pellet p = other.GetComponent<Pellet>();
        if(p != null)
        {
            float pRadius = p.GetComponent<SphereCollider>().radius;
            float pVolume = (4f / 3) * Mathf.PI * Mathf.Pow(pRadius, 3);
            float aVolume = (4f / 3) * Mathf.PI * Mathf.Pow(agar.Radius, 3);
            float combinedVolume = pVolume + aVolume;
            float newRadius = Mathf.Pow((combinedVolume / ((4f / 3) * Mathf.PI)), 1 / 3f);
            p.Eat();
            agar.Radius = newRadius;
            agar.Eaten = true;
        }
    }
}
