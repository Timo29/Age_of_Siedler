using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarehouseCanvas : MonoBehaviour
{
    public TMPro.TextMeshProUGUI stoneAmount;
    public TMPro.TextMeshProUGUI woodAmount;

    private void Start()
    {
        GameManager.warehouseStone += addStone;
        GameManager.warehouseWood += addWood;
    }

    private void addStone(float stone)
    {
        
        stoneAmount.text = stone.ToString();
    }

    private void addWood(float wood)
    {
        woodAmount.text = wood.ToString();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }
}
