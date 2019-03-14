using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileRangeController : MonoBehaviour
{
    private float deletetime;
    private float spantime;
    private float nexttime;



    // Start is called before the first frame update
    void Start()
    {
        deletetime = 0.0f;
        spantime = 0f;
        nexttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        deletetime += Time.deltaTime;
        spantime += Time.deltaTime;

        if (deletetime < 3.5f)
        {
            if (spantime > 0.5f)
            {
                GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
                spantime = 0f;
            }
        }

        else if (deletetime < 5.0f)
        {
            if (spantime > 0.2f)
            {
                GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
                spantime = 0f;
            }
        }

        else if (deletetime > 5.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
