using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public Camera camera;
    public LayerMask groundLayer;
    public GameManager gm;

    [Header("Spawnable Objects")]
    public GameObject house;
    public BoxCollider houseCollider;
    public GameObject warehouse;
    public BoxCollider warehouseCollider;
    public Color transperenci;

    private int woodCostMain;
    private int stoneCostMain;

    internal int spawnBlockCount;
    public bool isHouse;
    internal bool isWarehouse;

    public delegate void WoodCost(int woodAmount);
    public static event WoodCost onWoodDec;

    public delegate void StoneCost(int stoneAmount);
    public static event StoneCost onStoneDec;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && (isHouse || isWarehouse))
        {
            UnSelect();
        }

        ObjectSet();
    }

    private void UnSelect()
    {
        isHouse = false;
        house.SetActive(false);
        isWarehouse = false;
        warehouse.SetActive(false);
    }

    private void ObjectSet()
    {
        if (isHouse)
        {
            RaycastHit hitInfo;
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo, groundLayer);
            house.transform.position = new Vector3(hitInfo.point.x, house.transform.position.y, hitInfo.point.z);
            Debug.Log(spawnBlockCount + " spawn block count");
            //ChangColor(house.transform.GetChild(1));
            if (Input.GetButtonDown("Fire1"))
            {
                if (spawnBlockCount == 0 && gm.wood >= woodCostMain && gm.stone >= stoneCostMain)
                {
                    GameObject buildingTemp = Instantiate(house, house.transform.position, Quaternion.identity);
                    buildingTemp.transform.GetChild(0).gameObject.SetActive(true);
                    buildingTemp.transform.GetChild(1).GetComponent<ObjectSpawnCollision>().enabled = false;
                    buildingTemp.transform.GetChild(1).gameObject.SetActive(false);
                    onWoodDec(woodCostMain);
                    onStoneDec(stoneCostMain);
                }
                else if (gm.wood <= woodCostMain && gm.stone <= stoneCostMain)
                {
                    UnSelect();
                }
            }
        }
        else if (isWarehouse)
        {
            RaycastHit hitInfo;
            Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo, groundLayer);
            Debug.Log(hitInfo.point);
            warehouse.transform.position = hitInfo.point;
        }
    }


    public void showHouse(int woodCost, int stoneCost)
    {
        woodCostMain = woodCost;
        stoneCostMain = stoneCost;
        Debug.Log("Spawn House");
        house.transform.GetChild(0).gameObject.SetActive(false);
        house.transform.GetChild(1).gameObject.SetActive(true);
        house.SetActive(true);
        isHouse = true;
    }

    public void showWarehouse()
    {
        warehouse.SetActive(true);
        isWarehouse = true;
    }

    // Könnte so vielleicht Funktionieren xD
    private void ChangColor(Transform objectToSpawn)
    {
        objectToSpawn.gameObject.GetComponent<Renderer>().material.color = transperenci;
    }
}
