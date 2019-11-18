using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    private SpawnHouseScript spawnHouse;



    private void Start()
    {
        spawnHouse = GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouseScript>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("house"))
        {
            spawnHouse.spawn = false;
            print("Working"); 
        }
    }

}
