using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boidDaddyHandler : MonoBehaviour
{
    BoidController boidController;

    // Start is called before the first frame update
    void Start()
    {
        boidController = GetComponentInChildren<BoidController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.GetComponent<bulletHandler>() != null)
        {
            Debug.Log("boid ball hit");
            boidController.KillBoidByNumber(Random.Range(0, boidController.boidList.Count - 1));
        }
    }
}
