﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHouseScript : MonoBehaviour
{
    enum ChanceDetails
    {
        house_Model



    }



    public Camera myCamera;

    public bool lagerBool = false;
    public bool dorfzBool = false;
    public bool spawn = false;

    public GameObject dorf;
    public GameObject lagerbase;


    [SerializeField]
    private GameObject[] housePrefabs;

    int houseIndex = 0;
    GameObject dorfZentrumHouse;



    public void housePrefabChange()
    {
        if (houseIndex < housePrefabs.Length)
        {
            houseIndex = 1;

        }

        lagerBool = true;




        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }

    public void lagerspawn()
    {
        if (houseIndex < housePrefabs.Length)
        {
            houseIndex = 0;
        }
        dorfzBool = true;
        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }




    void Update()
    {


        if (lagerBool == true)
        {
            lagerbase.SetActive(true);
            dorf.SetActive(false);
            dorfzBool = false;
            spawn = true;

        }

        else if (dorfzBool == true)
        {
            dorf.SetActive(true);
            lagerbase.SetActive(false);
            lagerBool = false;
            spawn = true;

        }


        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);


        Physics.Raycast(ray, out hit);
        {


            if (hit.transform.gameObject.tag == "floor")
            {

                dorf.transform.position = hit.point;
                lagerbase.transform.position = hit.point;
            }
            else
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (spawn == true)
                {
                    Instantiate(dorfZentrumHouse, hit.point, Quaternion.identity );
                    spawn = false;
                }
                lagerbase.SetActive(false);
                dorf.SetActive(false);
                lagerBool = false;
                dorfzBool = false;




            }




        }


    }










    void ApplyChange(ChanceDetails detail, int id)
    {

        switch (detail)
        {
            case ChanceDetails.house_Model:
                dorfZentrumHouse = housePrefabs[id];
                print(houseIndex);
                break;
        }

    }
}


