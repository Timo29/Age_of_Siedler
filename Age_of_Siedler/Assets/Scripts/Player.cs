using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public LineRenderer pathLine;
    internal Vector3 target;

    public ParticleSystem select;
    public bool isSelect = false;

    [Header("cargo")]
    public float maxCargo;
    public float currentCargo;
    public float workTime;
    public int workAmount;

    public Image work;
    public GameObject canvas;

    [Header("Resources")]
    internal bool wood;
    internal bool stone;

    [Header("Build")]
    internal Building building;
    internal bool build;

    [SerializeField]
    internal bool isWorking;
    internal Resource workResource;

    void Update()
    {
        if (isSelect)
        {
            DrawPath();
        }
        else
            pathLine.enabled = false;
    }

    public void DrawPath()
    {
        Debug.Log("DrawLine");
        pathLine.enabled = true;
        pathLine.positionCount = agent.path.corners.Length;
        pathLine.SetPositions(agent.path.corners);
    }

    IEnumerator Work()
    {
        if (workResource != null)
        {
            while (currentCargo < maxCargo)
            {
                currentCargo += workAmount;
                work.fillAmount = currentCargo / maxCargo;
                Debug.Log(currentCargo + " currentCargo");
                workResource.resourceAmount -= workAmount;
                yield return new WaitForSeconds(workTime);
            } 
        }
        else
        {
            target = transform.position;
        }

        yield return null;
    }

    IEnumerator Build()
    {
        if(building != null)
            while (building.buildTime > 0)
            {
                yield return new WaitForSeconds(1f);
                building.buildTime -= 1f;
            }


        yield return null;
    }

    //public static Vector3 RandomPointInHome(Vector3 zone)
    //{
    //    return new Vector3(
    //        Random.Range(zone.x + 2.5f, zone.x - 2.5f),
    //        0.5f,
    //        Random.Range(zone.z + 2.5f, zone.z - 2.5f));
    //}
}
