using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CameraController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void MissleShake()
    {
        transform.DOShakePosition(1f);
    }

    public void MSShake()
    {
        transform.DOShakePosition(0.1f);
    }

}
