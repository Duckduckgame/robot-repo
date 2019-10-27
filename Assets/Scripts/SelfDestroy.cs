using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// so yeah
public class SelfDestroy : MonoBehaviour
{
    public float timeTo = 10.0f;

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, timeTo);
    }
}
