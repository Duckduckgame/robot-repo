using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaddyDrone : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            transform.position += transform.forward * Input.GetAxis("Vertical") * speed;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position += transform.right * Input.GetAxis("Horizontal") * speed;
        }
    }
}
