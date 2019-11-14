using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int stoneAmount;
    public int woodAmount;
    public float buildTime;

    void Update()
    {
        if (buildTime <= 0f)
        {
            Debug.Log("Fertig");
        }
    }
}
