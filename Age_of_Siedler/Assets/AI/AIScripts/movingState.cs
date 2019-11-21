﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingState : StateMachineBehaviour
{
    Player aiController;
    Transform aiTransform;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController = animator.gameObject.GetComponent<Player>();
        aiTransform = animator.gameObject.GetComponent<Transform>();
        aiController.agent.isStopped = false;
        aiController.isMoving = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController.agent.SetDestination(aiController.target);

        if (Vector3.Distance(aiTransform.position, aiController.target) < 1.8f && aiController.isWorking)
        {
            if (aiController.build)
            {
                animator.SetBool("isBuilding", true);
            }
            else
            {
                animator.SetBool("isMining", true);

            }
        }
        else if(Vector3.Distance(aiTransform.position, aiController.target) < 1f)
        {
            animator.SetBool("isMoving", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        aiController.isMoving = false;
        animator.SetBool("isMoving", false);
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
