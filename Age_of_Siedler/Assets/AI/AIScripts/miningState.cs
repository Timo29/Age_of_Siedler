using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miningState : StateMachineBehaviour
{
    Player aiController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController = animator.gameObject.GetComponent<Player>();

        if (aiController != null)
        {
            aiController.StartCoroutine("Work");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aiController.currentCargo == aiController.maxCargo)
        {
            animator.SetBool("isDeliver", true);
        }
        else if(aiController.currentCargo > 0 && aiController.workResource == null)
        {
            aiController.StopCoroutine("Work");
            animator.SetBool("isDeliver", true);
        }
        else if (aiController.workResource == null && aiController.currentCargo == 0)
        {
            animator.SetBool("isMining", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isMining", false);
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
