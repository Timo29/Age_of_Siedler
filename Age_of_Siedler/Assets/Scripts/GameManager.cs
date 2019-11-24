using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [Header("Resources")]
    public float wood;
    public float stone;

    public NavMeshSurface nms;

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
        warehouseWood(wood);
    }

    private void AddStone(float stoneAmount)
    {
        stone += stoneAmount;
        warehouseStone(stone);
    }

    //private void ReBuildNavMesh()
    //{
    //    nms.BuildNavMesh();
    //}
}
