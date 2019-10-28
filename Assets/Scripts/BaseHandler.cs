using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundManager))]
public class BaseHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> turrets;
    [SerializeField]
    float life = 100;
    [SerializeField]
    GameObject Shield;

    [SerializeField]
    AudioClip shieldDownclip;
    [SerializeField]
    AudioClip explosionClip;

    SoundManager soundManager;
    BoidController boidController;

    GameObject player;

    public GameObject explosionParticles;

    bool shieldDown = false;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GetComponent<SoundManager>();

        foreach (GameObject GO in turrets)
        {
            GO.GetComponent<turretController>().belongsToBase = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        boidController = FindObjectOfType<BoidController>();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject GO in turrets)
        {
            if (GO.GetComponent<turretController>().dead)
            {
                turrets.Remove(GO);
                GO.GetComponent<turretController>().Die();
                

            }
        }   

        if(turrets.Count <= 0 && !shieldDown)
        {
            soundManager.PlayByClip(shieldDownclip);
            Destroy(Shield);
            shieldDown = true;
        }

        if(life <= 0 && shieldDown)
        {
            Die();
        }
    }
    public void Die()
    {
        FindObjectOfType<WinLose>().buildingCount--;
        soundManager.PlayByClip(explosionClip);
        boidController.RunTimeSpawn(player.transform.position, 30);
        Destroy(gameObject, 2f);
        Destroy(this);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoidBehaviour>() != null)
        {
            life--;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
    }
}
