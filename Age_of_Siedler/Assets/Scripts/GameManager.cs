using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Resources")]
    public float wood;
    public float stone;

    public NavMeshSurface nms;

    public Image loadingImage;

    public delegate void WarehouseCanvasStoneAmount(float stone);
    public static event WarehouseCanvasStoneAmount warehouseStone;

    public delegate void WarehouseCanvasWoodAmount(float wood);
    public static event WarehouseCanvasWoodAmount warehouseWood;

    void Start()
    {
        warehouseDeliver.onStoneAdd += AddStone;
        warehouseDeliver.onWoodAdd += AddWood;
        SpawnObjects.onWoodDec += DecWood;
        SpawnObjects.onStoneDec += DecStone;
        MasterManager.onStartMap += ReBuildNavMesh;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ReBuildNavMesh();
        }
    }

    private void DecStone(int stoneAmount)
    {
        stone -= stoneAmount;
        //warehouseWood(stone);
    }

    private void DecWood(int woodAmount)
    {
        wood -= woodAmount;
        //warehouseWood(wood);
    }

    private void AddWood(float woodAmount)
    {
        wood += woodAmount;
        //warehouseWood(wood);
    }

    private void AddStone(float stoneAmount)
    {
        stone += stoneAmount;
        warehouseStone(stone);
    }

    private void ReBuildNavMesh()
    {
        nms.BuildNavMesh();
    }

    //public void LoadScen()
    //{
    //    float loadingTime = 10;

    //    while (!(loadingTime <= 0))
    //    {
    //        loadingTime -= UnityEngine.Random.Range(0.1f, 0.6f);
    //        loadingImage.fillAmount = loadingTime / 10;
    //    }
    //}
}
