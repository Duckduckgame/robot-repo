using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    GameObject screenCanvas;
    GameObject dronesNumCanvas;

    // Start is called before the first frame update
    void Start()
    {
        screenCanvas = GameObject.Find("ScreenCanvas");
        dronesNumCanvas = GameObject.Find("DronesNum");
    }

    // Update is called once per frame
    void Update()
    {
        int testint = 3;
        Text text = dronesNumCanvas.GetComponent<Text>();
        text.text = "ROBO REVO BOYOS NUM: " + testint;
    }
}
