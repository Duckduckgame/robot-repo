using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class droneController : MonoBehaviour
{
    DroneHandler droneHandler;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        droneHandler = FindObjectOfType<DroneHandler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = droneHandler.droneDestination;
    }
}
