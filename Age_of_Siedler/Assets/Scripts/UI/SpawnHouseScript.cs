using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHouseScript : MonoBehaviour
{
    enum ChanceDetails
    {
        house_Model
    }

    public Text text;
    public LayerMask groundLayer;
    public Camera myCamera;

    public bool lagerBool = false;
    public bool dorfzBool = false;
    public bool spawnbuiling;
    public bool spawn = false;
    public bool spawnHouse = false;

    public GameObject dorf;
    public GameObject lagerbase;

    int villagerMax;
    int currentVillager;


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
        spawn = true;

        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }

    public void lagerspawn()
    {
        if (houseIndex < housePrefabs.Length)
        {
            houseIndex = 0;
        }
        dorfzBool = true;
        spawn = true;


        ApplyChange(ChanceDetails.house_Model, houseIndex);

    }
    void Update()
    {

        text.text = currentVillager.ToString() + " / " + villagerMax.ToString();




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


        if (Physics.Raycast(ray, out hit, 50, groundLayer))
        {
   

                dorf.transform.position = hit.point;
                lagerbase.transform.position = hit.point;
                spawnHouse = true;
            

            if (Input.GetMouseButtonDown(0))
            {
                if (spawn == true && spawnHouse == true)
                {
                    Instantiate(dorfZentrumHouse, hit.point, Quaternion.identity * Quaternion.Euler(0, 90, 0));
                    spawnbuiling = true;
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


        if (spawnbuiling == true)
        {
            if (houseIndex == 0)
            {
                villagerMax += 15;
                spawnbuiling = false;

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


