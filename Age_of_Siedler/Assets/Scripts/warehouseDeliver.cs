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
                gm.Resources += other.gameObject.GetComponent<Player>().currentCargo;
                other.gameObject.GetComponent<Player>().currentCargo = 0;
                other.gameObject.GetComponent<Animator>().SetBool("isMoving", true);
            } 
        }
    }
}
