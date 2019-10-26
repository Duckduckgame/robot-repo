using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHandler : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float endSize;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;

        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * endSize, Time.deltaTime * 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject,1f);
    }
}
