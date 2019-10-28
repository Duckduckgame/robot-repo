﻿//
// Boids - Flocking behavior simulation.
//
// Copyright (C) 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoidController : MonoBehaviour
{
    public GameObject boidPrefab;

    public GameObject droneDeathParticle;

    public List<GameObject> boidList;

    public int spawnCount = 10;

    public float spawnRadius = 4.0f;

    [Range(0.1f, 500.0f)]
    public float velocity = 6.0f;

    [Range(0.0f, 0.9f)]
    public float velocityVariation = 0.5f;

    [Range(0.1f, 20.0f)]
    public float rotationCoeff = 4.0f;

    [Range(0.1f, 10.0f)]
    public float neighborDist = 2.0f;

    public LayerMask searchLayer;

    void Start()
    {
        for (var i = 0; i < spawnCount; i++) Spawn();
    }

    public GameObject Spawn()
    {
        return Spawn(transform.position + Random.insideUnitSphere * spawnRadius);
    }

    public GameObject Spawn(Vector3 position)
    {
        var rotation = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);
        var boid = Instantiate(boidPrefab, position, rotation) as GameObject;
        if (boid.GetComponent<BoidBehaviour>())
            boid.GetComponent<BoidBehaviour>().controller = this;
        boidList.Add(boid);
        return boid;
    }

    public void RunTimeSpawn(Vector3 position)
    {
        var rotation = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);
        var boid = Instantiate(boidPrefab, position, rotation) as GameObject;
        if (boid.GetComponent<BoidBehaviour>())
            boid.GetComponent<BoidBehaviour>().controller = this;
        boidList.Add(boid);
    }

    public void RunTimeSpawn(Vector3 position, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var rotation = Quaternion.Slerp(transform.rotation, Random.rotation, 0.3f);
            var boid = Instantiate(boidPrefab, position, rotation) as GameObject;
            if (boid.GetComponent<BoidBehaviour>())
                boid.GetComponent<BoidBehaviour>().controller = this;
            boidList.Add(boid);
        }
    }

    // Just that, kill em all
    public void KillAllBoids()
    {
        foreach(var boid in boidList)
        {
            if(boid != null)
            {
                Instantiate(droneDeathParticle, boid.GetComponent<Transform>().transform.position, Quaternion.identity);
                boidList.Remove(boid);
                Destroy(boid);
            }
        }
    }

    // Can be called by the turret or other enemies to kill a specific boid
    public void KillBoidByInstance(GameObject boid)
    {
        Instantiate(droneDeathParticle, boid.GetComponent<Transform>().transform.position, Quaternion.identity);
        boidList.Remove(boid);
        Destroy(boid);
    }

    // Manual destruction of boids
    public void KillBoidByNumber(int listPosition)
    {

        var boid = boidList[listPosition];
        boidList.RemoveAt(listPosition);
        Instantiate(droneDeathParticle, boid.GetComponent<Transform>().transform.position, Quaternion.identity);
        Destroy(boid);
    }
}
