using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Transform wallPrefab;

    public BoxCollider worldSize;
    public float pRadius;
    private float wallExtents = 5f;

    void CreateWalls()
    {
        Transform wallLeft = Instantiate(wallPrefab);
        wallLeft.transform.position = new Vector3(worldSize.transform.position.x - worldSize.size.x/2 - pRadius - wallExtents, wallLeft.transform.position.y, wallLeft.transform.position.z);
        wallLeft.transform.localScale = new Vector3(10, worldSize.size.y, worldSize.size.z);
        Transform wallRight = Instantiate(wallPrefab);
        wallRight.transform.position = new Vector3(worldSize.transform.position.x + worldSize.size.x / 2 + pRadius + wallExtents, wallRight.transform.position.y, wallRight.transform.position.z);
        wallRight.transform.localScale = new Vector3(10, worldSize.size.y, worldSize.size.z);
        Transform wallFront = Instantiate(wallPrefab);
        wallFront.transform.position = new Vector3(wallFront.transform.position.x, wallFront.transform.position.y, worldSize.transform.position.z + worldSize.size.z / 2 + pRadius + wallExtents);
        wallFront.transform.localScale = new Vector3(worldSize.size.x, worldSize.size.y, 10);
        Transform wallBack = Instantiate(wallPrefab);
        wallBack.transform.position = new Vector3(wallBack.transform.position.x, wallBack.transform.position.y, worldSize.transform.position.z - worldSize.size.z / 2 - pRadius - wallExtents);
        wallBack.transform.localScale = new Vector3(worldSize.size.x, worldSize.size.y, 10);
        Transform wallTop = Instantiate(wallPrefab);
        wallTop.transform.position = new Vector3(wallTop.transform.position.x, worldSize.transform.position.y + worldSize.size.y / 2 + pRadius + wallExtents, wallTop.transform.position.z);
        wallTop.transform.localScale = new Vector3(worldSize.size.x, 10, worldSize.size.z);
        Transform wallBottom = Instantiate(wallPrefab);
        wallBottom.transform.position = new Vector3(wallBottom.transform.position.x, worldSize.transform.position.y - worldSize.size.y / 2 - pRadius - wallExtents, wallBottom.transform.position.z);
        wallBottom.transform.localScale = new Vector3(worldSize.size.x, 10, worldSize.size.z);
    }
    private void Awake()
    {
        CreateWalls();
    }
}
