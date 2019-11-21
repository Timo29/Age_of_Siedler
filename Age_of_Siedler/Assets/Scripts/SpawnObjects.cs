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
    public GameObject warehouse;

    private int woodCostMain;
    private int stoneCostMain;

    internal bool spawnBlocked;
    public bool isHouse;
    internal bool isWarehouse;

    public delegate void WoodCost(int woodAmount);
    public static event WoodCost onWoodDec;

    public delegate void StoneCost(int stoneAmount);
    public static event StoneCost onStoneDec;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
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
            if (Input.GetButtonDown("Fire1"))
            {
                if (!spawnBlocked && gm.wood >= woodCostMain && gm.stone >= stoneCostMain)
                {
                    Instantiate(house, house.transform.position, Quaternion.identity);
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
        house.SetActive(true);
        isHouse = true;
    }

    public void showWarehouse()
    {
        warehouse.SetActive(true);
        isWarehouse = true;
    }
}
