using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLose : MonoBehaviour
{
    BoidController boidController;

    // Start is called before the first frame update
    void Start()
    {
        boidController = FindObjectOfType<BoidController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boidController.boidList.Count <= 0)
        {
            SceneManager.LoadSceneAsync(0);
        }

    }
}
