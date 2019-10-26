using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class tempCam : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    Camera renderCam;
    [SerializeField]
    GameObject renderPlane;
    [SerializeField]
    GameObject daddy;
    Vector3 hitPoint = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = renderCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == renderPlane)
            {
                ray = mainCam.ViewportPointToRay(new Vector3(hit.textureCoord.x, hit.textureCoord.y, 0));
                if(Physics.Raycast(ray, out hit))
                {
                    hitPoint = hit.point;
                    //daddy.GetComponent<NavMeshAgent>().destination = hitPoint;
                    daddy.transform.position = hitPoint + new Vector3(0,10,0);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hitPoint, 20f);

    }
}
