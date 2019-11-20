using System;
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
    public ResourceManager rm;
    internal bool isSelect = false;

    [Header("cargo")]
    public float maxCargo;
    public float currentCargo;
    public float workTime;
    public int workAmount;

    public Image work;
    public GameObject canvas;

    [Header("Resources")]
    public float resourceSearchRange;
    internal bool wood;
    internal bool stone;

    [Header("Build")]
    internal Building building;
    internal bool build;

    internal bool isWorking;
    internal bool newResource = false;
    public Resource workResource;

    void Update()
    {
        if (isSelect)
        {
            DrawPath();
        }
        else
            pathLine.enabled = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, resourceSearchRange);
    }

    public void DrawPath()
    {
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
                workResource.resourceAmount -= workAmount;
                yield return new WaitForSeconds(workTime);
            }
        }
        else
        {
            if (wood)
                NextWoodResource();
            else if (stone)
                NextStoneResource();
            yield return new WaitForSeconds(0.5f);
            newResource = true;
        }

        yield return null;
    }

    private void NextStoneResource()
    {
        for (int i = 0; i < rm.stoneCatalog.Count; i++)
        {
            if (Vector3.Distance(rm.stoneCatalog[i].transform.position, target) < resourceSearchRange)
            {
                workResource = rm.stoneCatalog[i].GetComponent<Resource>();
                target = rm.stoneCatalog[i].transform.position;
                stone = true;
                isWorking = true;
                return;
            }
        }
    }

    private void NextWoodResource()
    {
        for (int i = 0; i < rm.woodCatalog.Count; i++)
        {
            Debug.Log(i);
            if (Vector3.Distance(rm.woodCatalog[i].transform.position, target) < resourceSearchRange)
            {
                workResource = rm.woodCatalog[i].GetComponent<Resource>();
                target = rm.woodCatalog[i].transform.position;
                wood = true;
                isWorking = true;
                return;
            }
        }
    }

    IEnumerator Build()
    {
        if (building != null)
            while (building.buildTime > 0)
            {
                yield return new WaitForSeconds(1f);
                building.buildTime -= 1f;
            }


        yield return null;
    }
}
