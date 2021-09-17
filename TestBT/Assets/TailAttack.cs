using System;
using System.Collections;
using System.Collections.Generic;
using FSM.Player;
using UnityEngine;

public class TailAttack : MonoBehaviour
{
    void Start()
    {
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (DragonController.instance.tailcollider == true)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Triger True");
                PlayerController.Instance.TakeDamage(DragonController.instance.taildamage);
    
                DragonController.instance.tailcollider = false;
            }
        }
    }

    void Update()
    {
    }
}