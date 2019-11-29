using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gm;
    public SpawnObjects sp;

    [Header("Villager Spawn")]
    GameObject[] spawnPoints;
    public GameObject villagerPrefab;

    public delegate void SpawnVillagerWoodCost(int woodCost);
    public static event SpawnVillagerWoodCost onSpawnVillagerWoodCost;

    public delegate void SpawnVillagerStoneCost(int stoneCost);
    public static event SpawnVillagerStoneCost onSpawnVillagerStoneCost;


    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("VillagerSpawn");
        MenuManager.onSpawnVillager += VillagerSpawn;
        MenuManager.onSpawnHouse += HouseSpawn;
        MenuManager.onSpawnWarehouse += WarehouseSpawn;
    }
    private void VillagerSpawn(int costWood, int costStone)
    {
        if (gm.wood >= costWood && gm.stone >= costStone)
        {
            Instantiate(villagerPrefab, spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
            onSpawnVillagerWoodCost(costWood);
            onSpawnVillagerStoneCost(costStone);

        }
        else
            Debug.Log("Nicht genug Resourcen");
    }
    private void HouseSpawn(int costWood, int costStone)
    {
        if (gm.wood >= costWood && gm.stone >= costStone)
        {
            sp.isWarehouse = false;
            sp.warehouse.SetActive(false);
            sp.showHouse(costWood, costStone);
        }
        else
            Debug.Log("Nicht genug Resourcen");
    }
    private void WarehouseSpawn(int costWood, int costStone)
    {
        if (gm.wood >= costWood && gm.stone >= costStone)
        {
            sp.isHouse = false;
            sp.house.SetActive(false);
            sp.showWarehouse(costWood, costStone);
        }
        else
            Debug.Log("Nicht genug Resourcen");
    }

}
