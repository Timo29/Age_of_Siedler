using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshControll : MonoBehaviour
{
    NavMeshSurface nms;

    // Start is called before the first frame update
    void Start()
    {
        nms = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            nms.BuildNavMesh();
        }
    }
}
