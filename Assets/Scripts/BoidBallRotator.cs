using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBallRotator : MonoBehaviour
{
    [SerializeField]
    GameObject torusOne;
    [SerializeField]
    GameObject torusTwo;

    [SerializeField]
    float rotAmount;
    [SerializeField]
    float vecLerpSpeed = 1f;

    Vector3 oldvec = Vector3.zero;
    Vector3 randomVec = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oldvec = randomVec;
        randomVec = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Vector3 useVec = Vector3.Lerp(oldvec, randomVec, Time.deltaTime * vecLerpSpeed);
        transform.Rotate(useVec, rotAmount);
        torusOne.transform.Rotate(Vector3.down, rotAmount);
        torusTwo.transform.Rotate(Vector3.right, rotAmount);

        
    }
}
