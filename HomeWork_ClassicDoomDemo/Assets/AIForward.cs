using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIForward : StateMachineBehaviour
{
    [SerializeField] private float range = 10f;
    
    private RaycastHit hit;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AI_Movement>().direction = 1;
    }
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics.Raycast(animator.transform.position,
            (animator.GetComponent<AI_Movement>().pointOfInterest.transform.position - animator.transform.position)
            .normalized,
            out hit,
            range))
        {
            if (hit.transform.CompareTag("Player"))
            {
                animator.SetTrigger("Shoot");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<AI_Movement>().direction = 0;
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
