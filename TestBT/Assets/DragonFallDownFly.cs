using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonFallDownFly : StateMachineBehaviour
{
    DragonController dragon;
    NavMeshAgent dragonnav;

    Vector3 dragonposition;
    float height = 60f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DragonController.instance.dragonfalldown = false;

        dragonnav = animator.GetComponent<NavMeshAgent>();
        
        dragonposition = animator.transform.position;
        dragon = animator.GetComponent<DragonController>();

        if (dragon.falldowncrack.activeSelf == true)
        {
            dragon.falldowncrack.SetActive(false);
        }

        animator.ResetTrigger("FallDownStay");
        animator.ResetTrigger("Walk");
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragonnav.baseOffset += Time.deltaTime * 15;

        if (animator.transform.position.y > height)
        {
            animator.SetTrigger("FallDownStay");
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
