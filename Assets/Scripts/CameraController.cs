﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float scrollspeed = 25f;
    [SerializeField]
    float WASDspeed = 100f;
    [SerializeField]
    float yMin = 3f;
    [SerializeField]
    float yMax = 200f;

    Rigidbody rigidBody;

    Vector3 posVelocity;
    Vector3 zoomVelocity; //global variable here to keep zooming smooth

    [Range(.5f, .99f)]
    public float zoomSmoothing = .8f;

    // Start is called before the first frame update
    void Start()
    {        
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ZoomUpdate();
        PositionUpdate();

        rigidBody.velocity = (zoomVelocity + posVelocity);

    }

    private void ZoomUpdate()
    {
        Vector3 deltaZoomVelocity = transform.forward.normalized * scrollspeed;

        //gently nudge back in if we're on the edge of y bounds:
        if (rigidBody.position.y < yMin)
        {
            zoomVelocity -= deltaZoomVelocity;
            return;
        }
        if (rigidBody.position.y > yMax)
        {
            zoomVelocity += deltaZoomVelocity;
            return;
        }

        //getting input:
        float scrollY = Input.mouseScrollDelta.y;

        if (scrollY > 0)
            zoomVelocity += deltaZoomVelocity;
        if (scrollY < 0)
            zoomVelocity -= deltaZoomVelocity;

        //if we've come this far, we aren't changing zoom amount, so let's smooth the zoomVelocity
        zoomVelocity *= zoomSmoothing;

    }

    private void PositionUpdate()
    {

        Vector3 heading = new Vector3(0, 0, 0);

        //get local direciton:
        float forward = Input.GetAxis("Vertical");
        float lateral = Input.GetAxis("Horizontal");

        //change to rotated direciton:
        heading += transform.forward * forward;
        heading += transform.right * lateral;

        //remove the y-component, keeping the cam on the same horizontal plane:
        heading.y = 0;

        heading.Normalize();

        heading *= Time.deltaTime * WASDspeed;


        /*
        //Z:
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            //do nothing
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            heading.z = Time.deltaTime * WASDspeed * Input.GetAxis("Vertical");


            //X:
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //do nothing
            }
            else if (Input.GetKey(KeyCode.A))
            {
                heading.x = -Time.deltaTime * WASDspeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                heading.x = Time.deltaTime * WASDspeed;
            }
            */
            posVelocity = heading;
        }
    }



