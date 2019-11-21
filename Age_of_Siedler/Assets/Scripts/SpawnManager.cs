using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager gm;
    public SpawnObjects sp;

    void Start()
    {
        MenuManager.onSpawnVillager += VillagerSpawn;
        MenuManager.onSpawnHouse += HouseSpawn;
        MenuManager.onSpawnWarehouse += WarehouseSpawn;
    }
    private void VillagerSpawn(int costWood, int costStone)
    {
        if (gm.wood >= costWood && gm.stone >= costStone)
        {
            //Instantiate(Villager, Village.transform.position, Quaternion.identity);
            gm.wood -= costWood;
            gm.stone -= costStone;
        }
        else
            Debug.Log("Nicht genug Resourcen");
    }
    private void HouseSpawn(int costWood, int costStone)
    {
        if (gm.wood >= costWood && gm.stone >= costStone)
        {
            //sp.isWarehouse = false;
            //sp.warehouse.SetActive(false);
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
            sp.showWarehouse();
        }
        else
            Debug.Log("Nicht genug Resourcen");
    }

}
