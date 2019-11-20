using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warehouseDeliver : MonoBehaviour
{
    public delegate void StoneDelivery(float stoneAmount);
    public static event StoneDelivery onStoneAdd;

    public delegate void WoodDelivery(float woodAmount);
    public static event WoodDelivery onWoodAdd;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "resident")
        {
            if (other.gameObject.GetComponent<Player>().isWorking)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (player.stone)
                {
                    onStoneAdd(player.currentCargo);
                    player.currentCargo = 0;
                    player.work.fillAmount = 0;
                    other.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                }
                else if (player.wood)
                {
                    onWoodAdd(player.currentCargo);
                    player.currentCargo = 0;
                    player.work.fillAmount = 0;
                    other.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                }
            } 
        }
    }
}
