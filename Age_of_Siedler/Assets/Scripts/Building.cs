using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int stoneAmount;
    public int woodAmount;
    public float buildTime;

    public GameObject house;
    public GameObject houseInBuild;

    public delegate void Build();
    public static event Build onBuilding;

    void Update()
    {
        if (buildTime <= 0f)
        {
            Debug.Log("Fertig");
            houseInBuild.gameObject.SetActive(false);
            house.gameObject.SetActive(true);
            onBuilding();

        }
    }
}
