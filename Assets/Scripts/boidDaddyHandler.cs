using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boidDaddyHandler : MonoBehaviour
{
    BoidController boidController;

    int boidNum;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        boidController = GetComponentInChildren<BoidController>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        boidNum = boidController.boidList.Count;
        audioSource.pitch = (boidNum / 250);
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.GetComponent<bulletHandler>() != null)
        {

            boidController.KillBoidByNumber(Random.Range(0, boidController.boidList.Count - 1));
        }
    }
}
