using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 target;

    public GameObject mark;

    [Header("cargo")]
    public int maxCargo;
    public int currentCargo;
    public float workTime;
    public int workAmount;

    [Header("Resources")]
    internal bool wood;
    internal bool stone;

    [Header("Build")]
    internal Building building;
    internal bool build;

    [SerializeField]
    internal bool isWorking;
    internal Resource workResource;


    IEnumerator Work()
    {
        if (workResource != null)
        {
            while (currentCargo < maxCargo)
            {
                yield return new WaitForSeconds(workTime);
                currentCargo += workAmount;
                workResource.resourceAmount -= workAmount;
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
