using System.Collections;
using System.Collections.Generic;
using FSM.Player;
using UnityEngine;

public class RushAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (DragonController.instance.rushcollider == true)
        {
            if (other.tag == "Player")
            {
                PlayerController.Instance.TakeDamage(DragonController.instance.rushdamage);
    
                DragonController.instance.rushcollider = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
