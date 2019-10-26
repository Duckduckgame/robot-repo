using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Vector3 startPosition = new Vector3(0, 20, -10);
    [SerializeField]
    Vector3 startAngle = new Vector3(60, 0, 0);
    [SerializeField]
    float scrollspeed = 25f;
    [SerializeField]
    float WASDspeed = 25f;
    [SerializeField]
    float yMin = 3f;
    [SerializeField]
    float yMax = 200f;

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(startAngle);

        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camForce = new Vector3(0f, 0f, 0f);

        camForce += ZoomUpdate();
        camForce += PositionUpdate();

        rigidBody.velocity = camForce;
        



    }

    private Vector3 ZoomUpdate()
    {
        //skip the function if we're on the edge of bounds:
        if (rigidBody.position.y <= yMin || rigidBody.position.y >= yMax) return new Vector3(0f, 0f, 0f);


        float scrollAmt = Input.mouseScrollDelta.y * scrollspeed;
        Vector3 heading = transform.forward.normalized * scrollAmt;

        return heading;
        
    }

    private Vector3 PositionUpdate()
    {
        
        Vector3 heading = new Vector3(0, 0, 0);
        
        //Z:
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            //do nothing
        }
        else if (Input.GetKey(KeyCode.W))
        {
            heading.z = Time.deltaTime * WASDspeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            heading.z = -Time.deltaTime * WASDspeed;
        }

        //X:
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            heading.x = Time.deltaTime * WASDspeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            heading.x = -Time.deltaTime * WASDspeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            heading.x = Time.deltaTime * WASDspeed;
        }

        return heading;
        

    }
}

