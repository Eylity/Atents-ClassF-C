using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorStrike : MonoBehaviour
{
    public GameObject meteor;
    public GameObject meteoreffect;

    GameObject Target;

    Vector3 direct;

    float speed;

    void Start()
    {
        speed = 60f;

        Target = GameObject.FindWithTag("Player");

        this.transform.LookAt(Target.transform.position);

        direct = Target.transform.position - this.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            FSM.Player.PlayerController.GetPlayerController.TakeDamage(DragonController.instance.fireraindamage);

            speed = 0f;

            StartCoroutine(meteorend());
        }
        else if ((other.gameObject.tag == "Red" && this.gameObject.tag == "Red")
            || (other.gameObject.tag == "Blue" && this.gameObject.tag == "Blue")
            || (other.gameObject.tag == "Green" && this.gameObject.tag == "Green"))
        {
            speed = 0f;

            StartCoroutine(meteorend());
        }
    }

    IEnumerator meteorend()
    {
        meteor.gameObject.SetActive(false);

        meteoreffect.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        this.gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
