//Autor: Stöckmann Timo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float buildTime;

    public GameObject house;
    public GameObject houseInBuild;

    void Update()
    {
        if (buildTime <= 0f)
        {
            houseInBuild.gameObject.SetActive(false);
            house.gameObject.SetActive(true);
        }
    }
}
