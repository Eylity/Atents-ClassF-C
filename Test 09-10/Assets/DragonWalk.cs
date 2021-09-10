using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonWalk : StateMachineBehaviour
{
    DragonController dragon;
    NavMeshAgent dragonnav;

    Transform target;

    Vector3 directvector;
    Vector3 rotatevector;

    float distance;

    int randompattern;

    float walktime = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dragon = animator.GetComponent<DragonController>();
        dragonnav = animator.GetComponent<NavMeshAgent>();

        target = dragon.playerobject.transform;

        dragonnav.isStopped = false;

        animator.ResetTrigger("TailattackIdle");
        animator.ResetTrigger("BreathIdle");
        animator.ResetTrigger("RushIdle");
        animator.ResetTrigger("FallDownReady");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.LookAt(target.position);
        //Quaternion targetrotate = Quaternion.LookRotation(target.position);
        //animator.transform.rotation = Quaternion.Lerp(animator.transform.rotation, targetrotate, Time.deltaTime);     
        /*
        animator.transform.position += directvector.normalized * Time.deltaTime * dragon.speed;

        target.position = dragon.playerobject.transform.position;
        directvector = target.position - animator.transform.position;
        rotatevector = Vector3.RotateTowards(animator.transform.forward, directvector.normalized, Time.deltaTime*0.5f, 0.0f);
        animator.transform.rotation = Quaternion.LookRotation(rotatevector);        
        */
        target.position = dragon.playerobject.transform.position;
        dragonnav.SetDestination(target.position);

        walktime += Time.deltaTime;

        distance = Vector3.Distance(target.position, animator.transform.position);

        if (dragon.hp <= 70f && DragonController.instance.dragonfalldown == true)
        {
            dragonnav.isStopped = true;
            animator.SetTrigger("FallDownReady");
        }
        else if (dragon.hp <= 30f && DragonController.instance.dragonfirerain == true && DragonController.instance.dragonfalldown == false)
        {
            animator.SetTrigger("FireRainReady");
        }

        if (distance <= 8f && walktime <= 7f)
        {
            dragonnav.isStopped = true;
            animator.SetTrigger("TailattackIdle");
            walktime = 0f;
        }
        else if(distance > 8f && walktime > 7f)
        {
            randompattern = Random.Range(0, 10);
            if (randompattern < 5)
            {
                dragonnav.isStopped = true;
                animator.SetTrigger("BreathIdle");
                walktime = 0f;
            }
            else
            {
                dragonnav.isStopped = true;
                animator.SetTrigger("RushIdle");
                walktime = 0f;
            }
        }
        else
        {
            return;
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
