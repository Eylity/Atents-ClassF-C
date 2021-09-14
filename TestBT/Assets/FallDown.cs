using System.Collections;
using System.Collections.Generic;
using FSM.Player;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DragonController.instance.falldowncollider == true)
        {
            if (other.tag == "Player")
            {
                PlayerController.GetPlayerController.TakeDamage(DragonController.instance.falldowndamage);
    
                DragonController.instance.falldowncollider = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
