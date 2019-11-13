using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(5f, 1f, 5f));
    }
}
