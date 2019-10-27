using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundManager))]
public class BaseHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> turrets;

    [SerializeField]
    GameObject Shield;

    [SerializeField]
    AudioClip shieldDownclip;

    SoundManager soundManager;

    bool shieldDown = false;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GetComponent<SoundManager>();

        foreach (GameObject GO in turrets)
        {
            GO.GetComponent<turretController>().belongsToBase = true;
        }


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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
    }
}
