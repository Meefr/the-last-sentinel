using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardianDrone : MonoBehaviour
{
    private Transform player;
    NavMeshAgent agent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 height = new Vector3(transform.position.x,player.transform.position.y + 3 ,transform.position.z);
        transform.position = height;

        agent.SetDestination(player.transform.position);
        
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = targetRotation;
    }
}
