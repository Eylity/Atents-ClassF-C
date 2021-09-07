using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Human.FSM.Player;

public class DragonController : MonoBehaviour
{
    public static DragonController instance;

    public GameObject playerobject;
    public Human.FSM.Player.PlayerController player;
    public float speed = 3.0f;

    public float hp = 100f;

    public bool dragonfalldown;
    public bool dragonfirerain;

    public GameObject collectfire;
    public GameObject falldownsmoke;
    public GameObject rushsmoke;
    public GameObject falldowncrack;
    public GameObject collectfire2;

    private void Awake()
    {
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
        player = playerobject.GetComponent<Human.FSM.Player.PlayerController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}