using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireRain : MonoBehaviour
{
    float distance;

    float radian;

    Vector3 axis;

    Vector3 newposition;
    Vector3 newrotation;

    public Transform headposition;

    public GameObject pillarred;
    public GameObject pillarblue;
    public GameObject pillargreen;

    public GameObject redeffect;
    public GameObject blueeffect;
    public GameObject greeneffect;

    GameObject redmeteor;
    GameObject bluemeteor;
    GameObject greenmeteor;

    float counttime;
    float count;
    int random;
    bool bcolor = true;

    private void Awake()
    {
        count = 0f;

        float dragonheight = this.transform.position.y;
        axis = new Vector3(0, dragonheight, 0);

        distance = Vector3.Distance(transform.position, axis);

        radian = 0f; 
        
        redmeteor = Resources.Load("MeteorStrikeRed") as GameObject; 
        bluemeteor = Resources.Load("MeteorStrikeBlue") as GameObject; 
        greenmeteor = Resources.Load("MeteorStrikeGreen") as GameObject;
    }

    void Start()
    {
        pillarred.SetActive(true);
        pillarblue.SetActive(true);
        pillargreen.SetActive(true);
    }

    private void CircleMove()
    {
        float sinx = distance * Mathf.Sin(radian * Mathf.Deg2Rad);
        float cosz = distance * Mathf.Cos(radian * Mathf.Deg2Rad);

        newposition = new Vector3(sinx, axis.y, cosz);
        newrotation = new Vector3(0, 90 + radian, -20);

        this.transform.rotation = Quaternion.Euler(newrotation);
        this.transform.position = newposition;
    }

    IEnumerator FireRainEnd()
    {
        yield return new WaitForSeconds(4f);

        this.gameObject.SetActive(false);
    }


    void Update()
    {
        CircleMove();

        radian += Time.deltaTime * 10f;

        counttime += Time.deltaTime;

        if(counttime > 1f && bcolor == true && count < 3f)
        {
            random = Random.Range(0, 3);

            if(random == 0)
            {
                redeffect.SetActive(true);
            }
            else if( random == 1)
            {
                blueeffect.SetActive(true);
            }
            else if (random == 2)
            {
                greeneffect.SetActive(true);
            }

            bcolor = false;
        }

        if(counttime >12f && count < 3f)
        {
            if (random == 0)
            {
                redeffect.SetActive(false);
                Instantiate(redmeteor, headposition.transform.position, Quaternion.identity);
            }
            else if (random == 1)
            {
                blueeffect.SetActive(false);
                Instantiate(bluemeteor, headposition.transform.position, Quaternion.identity);
            }
            else if (random == 2)
            {
                greeneffect.SetActive(false);
                Instantiate(greenmeteor, headposition.transform.position, Quaternion.identity);
            }

            count++;
            counttime = 0;
            bcolor = true;
        }

        if(count == 3f)
        {
            StartCoroutine(FireRainEnd());
        }
    }
}
