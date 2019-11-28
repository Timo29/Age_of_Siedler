using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerCenterDestroyEverithing : MonoBehaviour
{
    Transform transform;
    Collider[] toDestroyObjects;
    public float radius;
    public LayerMask destroyObjectsLayer;

    void Start()
    {
        transform = GetComponent<Transform>();
        MasterManager.onCompliteMapBuild += DestroyAll;
    }

    void DestroyAll()
    {
        toDestroyObjects = Physics.OverlapSphere(transform.position, radius, destroyObjectsLayer);

        for (int i = 0; i < toDestroyObjects.Length; i++)
        {
            Destroy(toDestroyObjects[i].gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
