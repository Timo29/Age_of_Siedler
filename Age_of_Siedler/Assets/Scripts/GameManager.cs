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
        Resource.onResourceEmpty += ReBuildNavMesh;
        warehouseDeliver.onStoneAdd += AddStone;
        warehouseDeliver.onWoodAdd += AddWood;
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

    private void ReBuildNavMesh()
    {
        nms.BuildNavMesh();
    }
}
