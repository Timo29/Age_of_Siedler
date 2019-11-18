using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warehouseDeliver : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "resident")
        {
            if (other.gameObject.GetComponent<Player>().isWorking)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (player.stone)
                {
                    gm.stone += player.currentCargo;
                    player.currentCargo = 0;
                    player.work.fillAmount = 0;
                    other.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                }
                else if (player.wood)
                {
                    gm.wood += player.currentCargo;
                    player.currentCargo = 0;
                    player.work.fillAmount = 0;
                    other.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
                }
            } 
        }
    }
}
