using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    [Header("Resources")]
    public float wood;
    public float stone;

    public NavMeshSurface nms;

    void Start()
    {
        Resource.onResourceEmpty += ReBuildNavMesh;
    }

    private void ReBuildNavMesh()
    {
        nms.BuildNavMesh();
    }
}
