using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneHandler : MonoBehaviour
{
    public Vector3 droneDestination;
    [SerializeField]
    Camera viewingCamera;
    [SerializeField]
    GameObject droneGO;
    [SerializeField]
    GameObject daddy;
    [SerializeField]
    int droneAmount;

    GameObject[] drones;

    private void Awake()
    {
        for (int i = 0; i < droneAmount; i++)
        {
            GameObject GO = Instantiate(droneGO, droneGO.transform.position, Quaternion.identity);
            GO.GetComponent<droneController>().daddy = daddy;
        }
        droneGO.GetComponent<droneController>().daddy = daddy;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButton(0))
        {
            Debug.Log("click");
            RaycastHit hit;
            Ray ray = viewingCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                if(hit.collider.GetComponent<TerrainCollider>() != null)
                {
                    daddyAgent.destination = hit.point;
                }
            }
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(droneDestination, 10f);
    }

}

