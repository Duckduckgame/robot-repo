using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardScript : MonoBehaviour
{
    public GameObject mainCam;

    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main != null) mainCam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCam) transform.LookAt(mainCam.transform);
    }
}
