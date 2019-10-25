using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneHandler : MonoBehaviour
{
    public Vector3 droneDestination;
    [SerializeField]
    Camera viewingCamera;
    [SerializeField]
    GameObject daddyDrone;
    [SerializeField]
    int droneAmount;

    GameObject[] drones;

    private void Awake()
    {
        for (int i = 0; i < droneAmount; i++)
        {
            Instantiate(daddyDrone, daddyDrone.transform.position, Quaternion.identity);
            
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            RaycastHit hit;
            Ray ray = viewingCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
                if(hit.collider.GetComponent<TerrainCollider>() != null)
                {
                    droneDestination = hit.point;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(droneDestination, 10f);
    }

}

