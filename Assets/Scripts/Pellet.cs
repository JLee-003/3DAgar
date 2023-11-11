using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public System.Action<GameObject> generatorFunction;
    public float value = .01f;
    public bool isEaten => !gameObject.activeSelf;

    public void Eat()
    {
        gameObject.SetActive(false);
        generatorFunction.Invoke(gameObject);
        gameObject.SetActive(true);
    }
}
