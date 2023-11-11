using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public System.Action<GameObject> generatorFunction;
    public float value = .01f;
    public AgarCharacter agar;
    public bool isEaten;

    public void Eat()
    {
        gameObject.SetActive(false);
        generatorFunction.Invoke(gameObject);
        gameObject.SetActive(true);
    }
}
