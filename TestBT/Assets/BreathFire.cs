using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM.Player;

public class BreathFire : MonoBehaviour
{
    public CapsuleCollider breathcollider;

    void Start()
    {
        StartCoroutine(ColliderOn());
    }

    IEnumerator ColliderOn()
    {
        yield return new WaitForSeconds(1f);

        breathcollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DragonController.instance.breathcollider == true)
        {
            if (other.tag == "Player")
            {
                PlayerController.GetPlayerController.TakeDamage(DragonController.instance.breathdamage);

                breathcollider.enabled = false;
                DragonController.instance.breathcollider = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
