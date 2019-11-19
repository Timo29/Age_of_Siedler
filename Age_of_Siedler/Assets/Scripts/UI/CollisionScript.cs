using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    private SpawnHouseScript spawnHouse;



    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "house")
        {
         GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouseScript>().spawn = false;
            print("Collision");

        }

        else
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouseScript>().spawn = true;

        }
    }


}
