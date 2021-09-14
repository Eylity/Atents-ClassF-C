using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonFireRainDown : StateMachineBehaviour
{
    DragonController dragon;
    NavMeshAgent dragonnav;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<DragonController>();
        dragonnav = animator.GetComponent<NavMeshAgent>();

        dragon.dragonskin.SetActive(true);
        dragon.dragonfirerainobject.SetActive(false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragonnav.baseOffset -= Time.deltaTime * 15;

        if (animator.transform.position.y < 3f)
        {
            dragonnav.baseOffset = 0f;
            animator.SetTrigger("FireRainEnd");
        }
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
