using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawan : MonoBehaviour
{
    private float timeBtwDrones;
    public float startTimeBtwDrones;

    public GameObject Drone;

    void Start()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(Drone, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
