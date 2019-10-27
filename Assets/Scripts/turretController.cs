using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour
{
    enum fireMode {bullet, laser };
    [SerializeField]
    fireMode crntMode;
    [SerializeField]
    int life;
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
    GameObject laser;
    LineRenderer laserLineRenderer;
    [SerializeField]
    float fireTimer;
    float timeSinceFired = Mathf.Infinity;
    [SerializeField]
    float laserTimer;
    float timeSinceLasered = Mathf.Infinity;
    BoidController boidController;
    int boidCount = 0;
    GameObject player;

    Quaternion targetRot;
    Quaternion oldRot;

    [HideInInspector]
    public bool dead = false;
    bool agro = false;
    [HideInInspector]
    public bool belongsToBase = false;

    SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        boidController = FindObjectOfType<BoidController>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (crntMode == fireMode.laser) {
            GameObject go = Instantiate(laser, Vector3.zero, Quaternion.identity, transform);
            go.GetComponent<LineRenderer>().enabled = true;
            laserLineRenderer = go.GetComponent<LineRenderer>();
        }
        GetComponent<SphereCollider>().radius = detectionRange / 2;

        soundManager = GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        timeSinceFired += Time.deltaTime;
        timeSinceLasered += Time.deltaTime;
        if(Vector3.Distance(transform.position, player.transform.position) < detectionRange && boidCount > 3)
        {
            agro = true;
            turret.transform.LookAt(player.transform.position);
            if(crntMode == fireMode.bullet) FireBullet();
            if(crntMode == fireMode.laser) FireLaser();
        }
        else
        {
            agro = false;
            if (crntMode == fireMode.laser) StopLaser();
        }

        //turret.transform.rotation = Quaternion.Lerp(oldRot, crntRot, Time.deltaTime * rotSpeed);

        if(life <= 0)
        {
            dead = true;
            if (!belongsToBase) Die();
        }
    }

    private void FireBullet()
    {
        if (timeSinceFired > fireTimer)
        {
            timeSinceFired = 0;
            Instantiate(bullet, fireLocation.position, turret.transform.rotation);
            soundManager.PlayByID(0);
        }
    }

    void FireLaser()
    {
        laserLineRenderer.SetPosition(0, fireLocation.position);
        laserLineRenderer.SetPosition(1, player.transform.position);

        if(timeSinceLasered > laserTimer)
        {
            timeSinceLasered = 0;
            boidController.KillBoidByNumber(Random.Range(0, boidController.boidList.Count - 1));
            soundManager.PlayByID(1);
        }
    }

    void StopLaser()
    {
        laserLineRenderer.SetPosition(0, Vector3.zero);
        laserLineRenderer.SetPosition(1, Vector3.zero);
    }

    public void Die()
    {
        boidController.RunTimeSpawn(player.transform.position, 30);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoidBehaviour>() != null)
        {
            life--;
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Boid")
        {
            boidCount++;
        }
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
