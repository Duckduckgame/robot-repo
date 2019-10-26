using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{

    [SerializeField]
    float detectionRange;
    [SerializeField]
    float rotSpeed;
    [SerializeField]
    GameObject turret;
    [SerializeField]
    Transform fireLocation;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float fireTimer;
    float timeSinceFired = Mathf.Infinity;

    GameObject player;

    Quaternion targetRot;

    bool agro = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion oldRot = transform.rotation;
        timeSinceFired += Time.deltaTime;
        if(Vector3.Distance(transform.position, player.transform.position) < detectionRange)
        {
            agro = true;
            turret.transform.LookAt(player.transform.position);
            if(timeSinceFired > fireTimer)
            {
                timeSinceFired = 0;
                Instantiate(bullet, fireLocation.position, turret.transform.rotation);
            }
        }
        else
        {
            agro = false;
        }
        transform.rotation = Quaternion.Lerp(oldRot, transform.rotation, Time.deltaTime * rotSpeed);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        if (agro)
        {
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}
