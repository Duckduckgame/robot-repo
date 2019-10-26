using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{

    GameObject screenCanvas;
    GameObject dronesNumCanvas;

    BoidController boidController;

    // Start is called before the first frame update
    void Start()
    {
        boidController = FindObjectOfType<BoidController>().GetComponent<BoidController>();

        screenCanvas = GameObject.Find("ScreenCanvas");
        dronesNumCanvas = GameObject.Find("DronesNum");
    }

    // Update is called once per frame
    void Update()
    {

        int boidsNum = boidController.boidList.Count;

        Text text = dronesNumCanvas.GetComponent<Text>();
        text.text = "ROBO REVO BOYOS NUM: ";// + boidsNum;
    }
}
