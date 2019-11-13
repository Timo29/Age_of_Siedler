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

    [SerializeField]
    internal bool isWorking;
    internal Resources workResourc;

    IEnumerator Work()
    {
            while (currentCargo < maxCargo)
            {
                yield return new WaitForSeconds(workTime);
                currentCargo += 5; 
            }

        yield return null;
    }
}
