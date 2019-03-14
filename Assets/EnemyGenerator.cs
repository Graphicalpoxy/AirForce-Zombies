using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator: MonoBehaviour
{
    public GameObject enemyPref;
    private GameObject[] enemise;
    private GameObject[] generator;
    private float genetime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        generator = GameObject.FindGameObjectsWithTag("EnemyGenerator");

    }

    // Update is called once per frame
    void Update()
    {
        enemise = GameObject.FindGameObjectsWithTag("Enemy");

        genetime += Time.deltaTime;
        if (genetime > 1.0f)
        {
            genetime = 0;
            if (enemise.Length < 50)
            {
                int i = Random.Range(0, generator.Length);
                Instantiate(enemyPref, generator[i].transform.position, Quaternion.identity);
            }
        }
    }
}
