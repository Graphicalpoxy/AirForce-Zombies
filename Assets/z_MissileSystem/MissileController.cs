using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissileController : MonoBehaviour
{
    public GameObject effect;
    private GameObject player;
    private float X;
    private float Z;
    private GameObject SE;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        X = player.transform.position.x;
        Z = player.transform.position.z;
        transform.DOMove(new Vector3(X, 0, Z), duration: 5.0f).SetEase(Ease.Linear);
        SE = GameObject.Find("SEcontroller"); 


    }

    // Update is called once per frame
    void Update()
    {
    
       
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(effect, new Vector3 (transform.position.x, 0.6f, transform.position.z), Quaternion.identity);
        Camera.main.GetComponent<CameraController>().MissleShake();
        SE.GetComponent<SEController>().MissileSE();
        Destroy(this.gameObject);
    }

}
