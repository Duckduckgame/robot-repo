using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DaddyBrain is the brain of daddy. Daddy represents the unit that the flock follows.
/// 
/// </summary>

public class daddyBrain : MonoBehaviour
{
    private GameObject Daddy; // grab on awake, reference to this gobj
    public GameObject dronePrefab;

    public ArrayList droneList; // List of the drones that are currently following Daddy

    public int droneSpawnCount = 0; // Amount of drones to spawn at start
    public float spawnRadius = 5.0f; // Radial distance from Daddy to where we are spawning drones
    

    public LayerMask searchLayer; // Assign this layer to the drones so they know who to search


    private void Awake()
    {
        Daddy = GetComponent<GameObject>();
    }

    private void Start()
    {
        for(int i = 0; i < droneSpawnCount; ++i)
        {
            SpawnDrone(transform.position + Random.insideUnitSphere);
        }
    }

    /// <summary>
    /// Spawn a drone prefab at Vec3 position and add it to the list.
    /// </summary>
    /// <param name="position"></param> Position where the drone will be spawned at
    void SpawnDrone(Vector3 position)
    {
        Quaternion rotation = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);
        GameObject drone = Instantiate(dronePrefab, position, rotation) as GameObject;
        droneList.Add(drone);
    }

    public void KillDrone()
    {

    }
}
