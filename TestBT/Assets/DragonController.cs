using System.Collections;
using System.Collections.Generic;
using FSM.Player;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public static DragonController instance;

    public GameObject playerobject;
    public FSM.Player.PlayerController player;
    public float speed = 3.0f;

    public float hp = 100f;

    public bool dragonfalldown;
    public bool dragonfirerain;

    public GameObject collectfire;
    public GameObject breathfire;

    public GameObject falldownsmoke;
    public GameObject falldowncollision;

    public GameObject rushsmoke;
    public GameObject falldowncrack;
    public GameObject collectfire2;

    public GameObject dragonskin;
    public GameObject dragonfirerainobject;

    public GameObject tailspark;
    public GameObject rushspark1;
    public GameObject rushspark2;

    public float taildamage;
    public float rushdamage;
    public float breathdamage;
    public float falldowndamage;
    public float fireraindamage;

    public bool tailcollider;
    public bool breathcollider;
    public bool rushcollider;
    public bool falldowncollider;

    private void Awake()
    {
        tailcollider = false;
        rushcollider = false;
        breathcollider = false;
        falldowncollider = false;

        dragonfalldown = true;
        dragonfirerain = true;

        if(instance == null)
        {
            instance = this;
        }

        if (collectfire.activeSelf == true)
        {
            collectfire.SetActive(false);
        }

        if (collectfire2.activeSelf == true)
        {
            collectfire2.SetActive(false);
        }

        if (falldownsmoke.activeSelf == true)
        {
            falldownsmoke.SetActive(false);
        }

        if (rushsmoke.activeSelf == true)
        {
            rushsmoke.SetActive(false);
        }

        if (falldowncrack.activeSelf == true)
        {
            falldowncrack.SetActive(false);
        }

        playerobject = GameObject.FindWithTag("Player");
        player = playerobject.GetComponent<PlayerController>();
    }

    void Start()
    {
        taildamage = 15f;
        rushdamage = 20f;
        breathdamage = 25f;
        falldowndamage = 30f;
        fireraindamage = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
