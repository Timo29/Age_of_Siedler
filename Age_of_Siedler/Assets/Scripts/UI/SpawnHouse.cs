using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHouse : GameManager
{
    enum ChanceDetails
    {
        house_Model
    }

    public Text text;
    public LayerMask groundLayer;
    public Camera myCamera;

    private bool lagerBool = false;
    private bool dorfzBool = false;
    public bool spawn = false;

    public bool buyAmount;



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

        if (wood <= 50)
        {
            buyAmount = false;
            print("Not Enought Money");

        }

        else if (wood >= 50)
        {
            buyAmount = true;
        }
        if (stone <= 50)
        {
            buyAmount = false;
            print("Not Enought Money");

        }

        else if (stone >= 50)
        {
            buyAmount = true;
        }


        lagerBool = true;
        spawn = true;

        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }

    public void lagerspawn()
    {
        if (houseIndex < housePrefabs.Length)
        {
            houseIndex = 0;
        }


        if (wood <= 50)
        {
            buyAmount = false;
            print("Not Enought Money");

        }

        else if (wood >= 50)
        {
            buyAmount = true;
        }
        if (stone <= 50)
        {
            buyAmount = false;
            print("Not Enought Money");

        }

        else if (stone >= 50)
        {
            buyAmount = true;
        }

        dorfzBool = true;
        spawn = true;


        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }
    void Update()
    {










        if (lagerBool == true)
        {
            lagerbase.SetActive(true);
            dorf.SetActive(false);
            dorfzBool = false;
        }

        else if (dorfzBool == true)
        {
            dorf.SetActive(true);
            lagerbase.SetActive(false);
            lagerBool = false;
        }


        RaycastHit hit;
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, 1000, groundLayer))
        {
   

                dorf.transform.position = hit.point;
                lagerbase.transform.position = hit.point;
            

            if (Input.GetMouseButtonDown(0))
            {
                if (spawn == true && buyAmount == true)
                {
                    Instantiate(dorfZentrumHouse, hit.point, Quaternion.identity * Quaternion.Euler(0, 90, 0));



                    spawn = false;
                    lagerBool = false;
                    dorfzBool = false;
                }
                else if (spawn == false)
                {
                    print("NotWorking");
                }
                lagerbase.SetActive(false);
                dorf.SetActive(false);

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


