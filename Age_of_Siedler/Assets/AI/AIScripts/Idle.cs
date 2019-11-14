using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : StateMachineBehaviour
{
    Player aiController;
    Transform aiTransform;
    Vector3 homePoint;
    float workMoveSpeed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController = animator.gameObject.GetComponent<Player>();
        aiTransform = animator.gameObject.GetComponent<Transform>();
        homePoint = aiTransform.position;
        workMoveSpeed = aiController.agent.speed;
        aiController.agent.speed = 0.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(aiController.agent.pathEndPosition, aiTransform.position) < 0.5f)
        {
            aiController.agent.SetDestination(RandomPointInIdle(homePoint));
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aiController.agent.speed = workMoveSpeed;
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

    public static Vector3 RandomPointInIdle(Vector3 zone)
    {
        return new Vector3(
            Random.Range(zone.x + 1f, zone.x - 1f),
            0.5f,
            Random.Range(zone.z + 1f, zone.z - 1f));
    }
}
