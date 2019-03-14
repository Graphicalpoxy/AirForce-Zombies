using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    public GameObject missilePref;
    public Vector3 missileposition;
    public GameObject missileRangePref;
    private bool missiletrigger;
    private float missiletime = 0f; 
    private GameObject player;

    public GameObject Cross;
    private GameObject obj;

    public GameObject MissileButtom;

    private float MGtime;
    private bool MGtrigger;
    public GameObject MGButtom;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");       
    }

    // Update is called once per frame
    void Update()
    {       
        MissileButtom.GetComponent<Image>().fillAmount = missiletime / 5;
        MGButtom.GetComponent<Image>().fillAmount = MGtime;


        if (missiletrigger == false)
        {
            missiletime += Time.deltaTime;
            if (missiletime > 5.0f)
            {
                missiletrigger = true;
            }
        }

        if (MGtrigger == false)
        {
            MGtime += Time.deltaTime;
            if (MGtime > 1.0f)
            {
                MGtrigger = true;
            }
        }
        



    }

    public void Missile ()
    {
        if (missiletrigger == true)
        {
            missileposition = GameObject.Find("Player").transform.position;
            missiletrigger = false;
            missiletime = 0;
            Instantiate(missilePref, new Vector3(missileposition.x, 1000, missileposition.z), Quaternion.Euler(180, 0, 0));
            Instantiate(missileRangePref, new Vector3(missileposition.x, 0.8f, missileposition.z), Quaternion.Euler(90, 0, 0));
        }
    }

    public void MG ()
    {
        if (MGtrigger == true)
        {
            MGtrigger = false;
            MGtime = 0f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(e => Vector3.Distance(player.transform.position, e.transform.position)).ToArray();
            obj = Instantiate(Cross, new Vector3(enemies[0].transform.position.x, enemies[0].transform.position.y + 1.0f, enemies[0].transform.position.z - 0.7f), Quaternion.identity);
            obj.transform.parent = enemies[0].transform;

            enemies[0].GetComponent<EnemyController>().MG();
        }
    }

}
