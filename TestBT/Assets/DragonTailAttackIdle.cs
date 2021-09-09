using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTailAttackIdle : StateMachineBehaviour
{
    DragonController dragon;

    Transform target;

    Vector3 directvector;
    Vector3 rotatevector;

    float idletime = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<DragonController>();
        target = dragon.playerobject.transform;
        animator.ResetTrigger("Tailattack");
        target.position = dragon.playerobject.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        directvector = target.position - animator.transform.position;
        rotatevector = Vector3.RotateTowards(animator.transform.forward, directvector.normalized, Time.deltaTime*0.5f, 0.0f);
        animator.transform.rotation = Quaternion.LookRotation(rotatevector);

        idletime += Time.deltaTime;
        //target.position = dragon.playerobject.transform.position;
        //Quaternion targetrotate = Quaternion.LookRotation(target.position);
        //animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, targetrotate, Time.deltaTime);   


        if (idletime > 3f)
        {
            animator.SetTrigger("Tailattack");

            idletime = 0f;
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
