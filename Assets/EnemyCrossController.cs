using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrossController : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.root.position.x, transform.root.position.y + 0.7f, transform.root.position.z - 0.7f);
        transform.rotation = Camera.main.transform.rotation;
    }
}
