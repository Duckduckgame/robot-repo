using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class droneController : MonoBehaviour
{
    DroneHandler droneHandler;
    NavMeshAgent navMeshAgent;

    public GameObject daddy;
    // Start is called before the first frame update
    void Start()
    {
        droneHandler = FindObjectOfType<DroneHandler>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = daddy.transform.position + daddy.transform.forward * 5;
        //targetPos += new Vector3(Random.Range(1f, 10f), 0, Random.Range(1f, 10f));
        navMeshAgent.destination = targetPos;
    }
}
