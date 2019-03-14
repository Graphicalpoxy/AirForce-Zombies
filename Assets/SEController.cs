using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour
{
    public GameObject MissileSEobj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MissileSE()
    {
        MissileSEobj.GetComponent<AudioSource>().Play();
    }

}
