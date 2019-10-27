using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hydroPlant : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;

    [SerializeField]
    bool invert = false;
    [SerializeField]
    Vector3 angle;

    private void Start()
    {

        if (invert) rotSpeed *= -1;
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.rotation *= Quaternion.Euler(angle * rotSpeed);
    }
}
