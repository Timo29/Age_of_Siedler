using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    private SpawnHouse spawnHouse;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "house")
        {
         GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouse>().spawn = false;
            print("Collision");

        }


    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "house")
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouse>().spawn = true;
            print("Collision Exit");

        }
    }


}
