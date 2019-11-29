using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    internal int resourceAmount = 100;

    public delegate void DelResource(GameObject thisGameObject, string tag);
    public static event DelResource onResourceDel;

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (onResourceDel != null)
        {
            onResourceDel(this.gameObject, this.tag);
        }
    }
}
