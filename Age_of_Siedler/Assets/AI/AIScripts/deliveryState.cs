using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliveryState : StateMachineBehaviour
{
    Player aiController;
    Transform aiTransform;

    private GameObject[] warehouse;
    private bool onShot = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController = animator.gameObject.GetComponent<Player>();
        aiTransform = animator.gameObject.GetComponent<Transform>();
        warehouse = GameObject.FindGameObjectsWithTag("warehouse");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!onShot)
        {
            onShot = true;
            aiController.agent.SetDestination(nextWarehouseFinder()); 
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        onShot = false;
        animator.SetBool("isDeliver", false);
    }

    private Vector3 nextWarehouseFinder()
    {
        Debug.Log("Suche WareHouse");
        Vector3 nextWarehouse = new Vector3();
        float closestWarehouse = 0;

        for (int i = 0; i < warehouse.Length; i++)
        {
            float currentDistance;

            currentDistance = Vector3.Distance(warehouse[i].transform.position, aiTransform.position);
            if (closestWarehouse == 0)
            {
                closestWarehouse = currentDistance;
                nextWarehouse = warehouse[i].transform.position;
            }

            else if (currentDistance < closestWarehouse)
            {
                closestWarehouse = currentDistance;
                nextWarehouse = warehouse[i].transform.position;
            }

        }
        return nextWarehouse;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
