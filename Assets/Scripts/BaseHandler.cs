using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHandler : MonoBehaviour
{
    [SerializeField]
    List<GameObject> turrets;

    [SerializeField]
    GameObject Shield;
    // Start is called before the first frame update
    void Start()
    {
        
        
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

        if(turrets.Count <= 0)
        {
            Debug.Log("shield down");
            Destroy(Shield);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
    }
}
