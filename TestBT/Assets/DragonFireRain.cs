using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireRain : MonoBehaviour
{
    float distance;

    float radian;

    public GameObject fireraintarget;
    bool firerainstart;

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
        firerainstart = false;
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
        this.transform.position = DragonController.instance.transform.position;

        this.transform.LookAt(fireraintarget.transform.position);

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
        iTween.MoveTo(gameObject, iTween.Hash("x", DragonController.instance.transform.position.x, "y", DragonController.instance.transform.position.y, "z", DragonController.instance.transform.position.z, "time", 6.0f, "easeType", iTween.EaseType.easeInOutQuad));

        yield return new WaitForSeconds(8f);

        this.gameObject.SetActive(false);
    }

    bool firerainend = false;

    void FireRain()
    {
        Debug.Log("시작");
        firerainstart = true;

        if (firerainend == false)
        {
            CircleMove();
        }

        radian += Time.deltaTime * 10f;

        counttime += Time.deltaTime;

        if (counttime > 3f && bcolor == true && count < 3f)
        {
            random = Random.Range(0, 3);

            if (random == 0)
            {
                redeffect.SetActive(true);
            }
            else if (random == 1)
            {
                blueeffect.SetActive(true);
            }
            else if (random == 2)
            {
                greeneffect.SetActive(true);
            }

            bcolor = false;
        }

        if (counttime > 15f && count < 3f)
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

        if (count == 3f)
        {
            this.transform.LookAt(DragonController.instance.transform.position);
            firerainend = true;
            StartCoroutine(FireRainEnd());
        }
    }

    float startcount = 0;

    void Update()
    {
        if (firerainstart != true)
        {
            iTween.MoveTo(gameObject, iTween.Hash("x", fireraintarget.transform.position.x, "y", fireraintarget.transform.position.y, "z", fireraintarget.transform.position.z, "time", 6.0f, "easeType", iTween.EaseType.easeInOutQuad, "oncomplete","FireRain"));

            startcount += Time.deltaTime;

            if (startcount > 6f)
            {
                firerainstart = true;
            }
            //iTween.MoveBy(gameObject, iTween.Hash("y", 60, "time", 5f, "easeType", iTween.EaseType.linear));
            //iTween.MoveBy(gameObject, iTween.Hash("z", 90, "time", 5f, "easeType", iTween.EaseType.linear));
        }
        else
        {
            FireRain();
        }
    }
}
