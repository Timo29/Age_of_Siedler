using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    internal int resourceAmount = 100;

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
