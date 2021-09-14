using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRush : StateMachineBehaviour
{ 

    float rushtime = 0f;

    DragonController dragon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DragonController.instance.rushcollider = true;

        animator.ResetTrigger("RushEnd");
        dragon = animator.GetComponent<DragonController>();

        if (dragon.rushsmoke.activeSelf == false)
        {
            dragon.rushsmoke.SetActive(true);
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position += animator.transform.forward.normalized * Time.deltaTime * 15f;

        rushtime += Time.deltaTime;

        if(rushtime>3f)
        {
            DragonController.instance.rushcollider = false;
            animator.SetTrigger("RushEnd");
            rushtime = 0f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
