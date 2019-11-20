using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    private SpawnHouseScript spawnHouse;

    public Material[] matrials;
    Renderer rend;


    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "house")
        {
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouseScript>().spawn = false;
            print("Collision");



        }



    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "house")
        {

            GameObject.FindGameObjectWithTag("UIManager").GetComponent<SpawnHouseScript>().spawn = true;


        }
    }











}
