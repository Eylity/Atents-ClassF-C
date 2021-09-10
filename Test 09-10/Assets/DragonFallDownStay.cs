using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFallDownStay : StateMachineBehaviour
{
    DragonController dragon;

    Transform target;

    Vector3 directvector;
    Vector3 rotatevector;

    float staytime = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<DragonController>();
        target = dragon.playerobject.transform;

        animator.ResetTrigger("FallDown");
        animator.ResetTrigger("Walk");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        target.position = dragon.playerobject.transform.position;
        directvector = target.position - animator.transform.position;
        rotatevector = Vector3.RotateTowards(animator.transform.forward, directvector.normalized, Time.deltaTime * 5f, 0.0f);
        rotatevector.y = 0;
        animator.transform.rotation = Quaternion.LookRotation(rotatevector);
        
        staytime += Time.deltaTime;

        if (staytime > 2f)
        {            
            animator.SetTrigger("FallDown");

            staytime = 0f;
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
