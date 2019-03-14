using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public Text scoretext;
    private int score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("ScoreController").GetComponent<ScoreController>().score;
        scoretext.GetComponent<Text>().text="SCORE:" + score.ToString();
    }

    


}
