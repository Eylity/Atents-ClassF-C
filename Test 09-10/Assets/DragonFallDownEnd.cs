using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonFallDownEnd : StateMachineBehaviour
{
    Vector3 heightzero;

    DragonController dragon;
    NavMeshAgent dragonnav;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<DragonController>();
        dragonnav = animator.GetComponent<NavMeshAgent>();
        dragonnav.baseOffset = 0f;


        if (dragon.falldowncrack.activeSelf == false)
        {
            dragon.falldowncrack.SetActive(true);
        }

        if (dragon.falldownsmoke.activeSelf == true)
        {
            dragon.falldownsmoke.SetActive(false);
        }

        Vector3 heightzero = animator.transform.position;
        heightzero.y = 0f;
        animator.transform.position = heightzero;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
