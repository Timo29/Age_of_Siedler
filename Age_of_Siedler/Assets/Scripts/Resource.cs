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

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(3f, 1f, 3f));
    }
}
