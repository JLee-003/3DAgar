using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public BoxCollider containedVolume;
    public int count = 4;

    public void Generate()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.transform.SetParent(this.transform);
            SetPosition(obj);
            //Pellet p = obj.GetComponent<Pellet>();
            //p.generatorFunction = SetPosition;
        }
    }
    public void SetPosition(GameObject obj)
    {
        Vector3 position = new Vector3(Random.Range(0, containedVolume.size.x), Random.Range(0, containedVolume.size.y), Random.Range(0, containedVolume.size.z));
        position += containedVolume.center - containedVolume.bounds.extents;
        obj.transform.localPosition = position;
    }
    private void Start()
    {
        Generate();
    }
}
