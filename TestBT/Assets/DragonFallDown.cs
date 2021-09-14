using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonFallDown : StateMachineBehaviour
{
    DragonController dragon;
    NavMeshAgent dragonnav;

    Transform target;

    Vector3 directvector;

    float accel = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        accel = 0f;

        animator.ResetTrigger("FallDownEnd");
        dragon = animator.GetComponent<DragonController>();

        DragonController.instance.falldowncollider = true;
        DragonController.instance.falldowncollision.SetActive(true);

        if (dragon.falldownsmoke.activeSelf == false)
        {
            dragon.falldownsmoke.SetActive(true);
        }

        dragonnav = animator.GetComponent<NavMeshAgent>();       

        target = dragon.playerobject.transform;

        iTween.MoveTo(animator.gameObject, iTween.Hash("x", target.transform.position.x, "y", target.transform.position.y + 2, "z", target.transform.position.z, "time", 3.0f, "easeType", iTween.EaseType.easeInQuart));

        directvector = target.position - animator.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.Translate(directvector.normalized * Time.deltaTime * accel, Space.World);
        //dragonnav.baseOffset -= Time.deltaTime * (accel + 1);

        if (animator.transform.position.y < 3f)
        {
            Vector3 dragonposition = animator.transform.position;
            dragonposition.y = 0;
            animator.transform.position = dragonposition;
            dragonnav.baseOffset = 0f;
            animator.SetTrigger("FallDownEnd");
        }

        //accel += Time.deltaTime * 20f;
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
