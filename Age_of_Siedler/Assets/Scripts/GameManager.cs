//Autor: Stöckmann Timo
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
    public float villagerMax;

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
        SpawnManager.onSpawnVillagerWoodCost += DecWood;
        SpawnManager.onSpawnVillagerStoneCost += DecStone;
        MasterManager.onStartMap += ReBuildNavMesh;
        MasterManager.onStartMap += InstanceResourceConts;
    }

    //zieht Stone aus dem Lager ab
    private void DecStone(int stoneAmount)
    {
        stone -= stoneAmount;
        warehouseStone(stone);
    }

    //zieht Wood aus dem Lager ab
    private void DecWood(int woodAmount)
    {
        wood -= woodAmount;
        warehouseWood(wood);
    }

    //fühgt Wood zum lager hinzu
    private void AddWood(float woodAmount)
    {
        wood += woodAmount;
        warehouseWood(wood);
    }

    //fühgt Stone zum lager hinzu
    private void AddStone(float stoneAmount)
    {
        stone += stoneAmount;
        warehouseStone(stone);
    }

    //Builded das NavMesh
    private void ReBuildNavMesh()
    {
        nms.BuildNavMesh();
    }

    //Gibt beim Starten das erste mal die Reouren an das Canvas weiter
    private void InstanceResourceConts()
    {
        warehouseStone(stone);
        warehouseWood(wood);
    }
}
