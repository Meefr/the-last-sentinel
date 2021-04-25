using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossMovement : MonoBehaviour
{
    private Transform player;
    NavMeshAgent agent;
    Animator animator;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > 7)
        {
            animator.SetBool("Run", true);
            agent.SetDestination(player.transform.position);
        }
        else if(Vector3.Distance(transform.position, player.transform.position) <= 5)
        {
            animator.SetBool("InRange", true);
            animator.SetBool("Run", false);
            agent.SetDestination(transform.position);
        }
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }

   
}
