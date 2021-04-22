using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EasyBotMovement : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent navMeshAgent;
    public float movementSpeed;
    public float rotationSpeed;
    Animator animator;
    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange())
        {
            stop();
            animator.SetBool("run", false);
        }
        else
        {
            move();
            animator.SetBool("run", true);
        }
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
       
        

    }
    private void move()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
    private void stop()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    private bool inRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 5)
        {
            return true;
        }
        else
            return false;
    }
}
