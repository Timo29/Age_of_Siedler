//Autor: Stöckmann Timo
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarehouseCanvas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI stoneAmount;
    public TMPro.TextMeshProUGUI woodAmount;
    public TMPro.TextMeshProUGUI villagerAmount;


    private void Start()
    {
        GameManager.warehouseStone += addStone;
        GameManager.warehouseWood += addWood;
        SpawnManager.onSpawnVillagerOrHouse += addVillager;
    }

    private void addStone(float stone)
    {
        
        stoneAmount.text = stone.ToString();
    }

    private void addWood(float wood)
    {
        woodAmount.text = wood.ToString();
    }

    private void addVillager(int currenVillager, int maxVillager)
    {
        string canvasShow = currenVillager.ToString() + " / " + maxVillager.ToString();
        villagerAmount.text = canvasShow;
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
