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

        Debug.Log(this.gameObject.tag);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("플레이어충돌");

            speed = 0f;

            StartCoroutine(meteorend());
        }
        else if ((other.gameObject.tag == "Red" && this.gameObject.tag == "Red")
            || (other.gameObject.tag == "Blue" && this.gameObject.tag == "Blue")
            || (other.gameObject.tag == "Green" && this.gameObject.tag == "Green"))
        {
            Debug.Log("같은색충돌");

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
