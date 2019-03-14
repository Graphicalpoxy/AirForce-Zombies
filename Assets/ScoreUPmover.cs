using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUPmover : MonoBehaviour
{
    private float X;
    private float Y;

    // Start is called before the first frame update
    void Start()
    {
        X = 300 - GetComponent<RectTransform>().localPosition.x;
        Y = 600 - GetComponent<RectTransform>().localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().localPosition.x < 300 && GetComponent<RectTransform>().localPosition.y <600)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x + X * Time.deltaTime, GetComponent<RectTransform>().localPosition.y + Y * Time.deltaTime, 0);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
