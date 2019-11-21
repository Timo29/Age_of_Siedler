using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public delegate void VillagerBuild(int costWood, int costStone);
    public static event VillagerBuild onSpawnVillager;

    public delegate void HouseBuild(int costWood, int costStone);
    public static event HouseBuild onSpawnHouse;

    public delegate void WarehouseBuild(int costWood, int costStone);
    public static event WarehouseBuild onSpawnWarehouse;

    [Header("Villager Cost")]
    public int villagerCostWood;
    public int villagerCostStone;
    public TMPro.TextMeshProUGUI villagerWoodAmount;
    public TMPro.TextMeshProUGUI villagerStoneAmount;

    [Header("House Cost")]
    public int houseCostWood;
    public int houseCostStone;
    public TMPro.TextMeshProUGUI houseWoodAmount;
    public TMPro.TextMeshProUGUI houseStoneAmount;

    [Header("Warehouse Cost")]
    public int warehouseCostWood;
    public int warehouseCostStone;
    public TMPro.TextMeshProUGUI warehouseWoodAmount;
    public TMPro.TextMeshProUGUI warehouseStoneAmount;

    private void Start()
    {
        villagerWoodAmount.text = villagerCostWood.ToString();
        villagerStoneAmount.text = villagerCostStone.ToString();
        houseWoodAmount.text = houseCostWood.ToString();
        houseStoneAmount.text = houseCostStone.ToString();
        warehouseWoodAmount.text = warehouseCostWood.ToString();
        warehouseStoneAmount.text = warehouseCostStone.ToString();
    }

    public void SpawnVillager()
    {
        onSpawnVillager(villagerCostWood, villagerCostStone);
    }

    public void SpawnHouse()
    {
        onSpawnHouse(houseCostWood, houseCostStone);
    }

    public void SpawnWarehouse()
    {
        onSpawnWarehouse(warehouseCostWood, warehouseCostStone);
    }
}
