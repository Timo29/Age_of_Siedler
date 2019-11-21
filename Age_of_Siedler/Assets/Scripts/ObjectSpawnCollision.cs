using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnCollision : MonoBehaviour
{
    private SpawnObjects spawnObjects;

    private void Start()
    {
        spawnObjects = GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnObjects>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        spawnObjects.spawnBlocked = true;
    }

    private void OnTriggerExit(Collider other)
    {
        spawnObjects.spawnBlocked = false;
    }
}
