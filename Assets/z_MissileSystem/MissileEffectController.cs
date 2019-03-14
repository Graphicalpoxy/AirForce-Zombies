using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEffectController : MonoBehaviour
{
    float livetime;

    // Start is called before the first frame update
    void Start()
    {
        livetime = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
         livetime -= Time.deltaTime;

        if (livetime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
