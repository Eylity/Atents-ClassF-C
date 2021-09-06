using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFallDownIdle : StateMachineBehaviour
{
    DragonController dragon;

    Transform target;

    Vector3 directvector;
    Vector3 rotatevector;

    float idletime = 0f;

    float knockdowncount = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        knockdowncount += 1f;
        dragon = animator.GetComponent<DragonController>();
        target = dragon.playerobject.transform;
        target.position = dragon.playerobject.transform.position;

        animator.ResetTrigger("KnockDownReady");
        animator.ResetTrigger("FallDownReady");
        animator.ResetTrigger("FallDown");
        animator.ResetTrigger("FallDownStay");
        animator.ResetTrigger("FallDownEnd");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target.position = dragon.playerobject.transform.position;
        directvector = target.position - animator.transform.position;
        rotatevector = Vector3.RotateTowards(animator.transform.forward, directvector.normalized, Time.deltaTime, 0.0f);
        rotatevector.y = 0;
        animator.transform.rotation = Quaternion.LookRotation(rotatevector);

        idletime += Time.deltaTime;
        //target.position = dragon.playerobject.transform.position;
        //Quaternion targetrotate = Quaternion.LookRotation(target.position);
        //animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, targetrotate, Time.deltaTime);   


        if (idletime > 1f)
        {
            if (knockdowncount >= 3f)
            {
                animator.SetTrigger("KnockDownReady");

                idletime = 0f;
            }
            else
            {
                animator.SetTrigger("FallDownReady");
            }
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
