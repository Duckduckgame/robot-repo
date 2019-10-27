using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHandler : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float endSize;

    BoidController boidController;

    private void Start()
    {
        boidController = FindObjectOfType<BoidController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed;

        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * endSize, Time.deltaTime * 5);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected " + collision.transform.name);
        if(collision.gameObject.GetComponent<boidDaddyHandler>() != null)
        {
            Debug.Log("boid ball hit");
            boidController.KillBoidByNumber(Random.Range(0, boidController.boidList.Count - 1));
        }
        Destroy(gameObject,0.01f);
    }*/
}
