using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HardBotMovement : MonoBehaviour
{
    private Transform player;
    NavMeshAgent navMeshAgent;
    public float movementSpeed;
    public float rotationSpeed;
    Animator animator;
    private AudioSource deathSound;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShootRange())
        {
            animator.SetBool("Run", false);
            stop();
        }
       
        else if(Vector3.Distance(transform.position, player.transform.position) > 8 && !animator.GetBool("died"))
        {
            animator.SetBool("Run", true);
            moveforward();
        }
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



    }
    private void moveforward()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
    private void moveBackward()
    {
        Vector3 destination = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z + 0.5f);
        navMeshAgent.SetDestination(destination);
    }
    private void stop()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    private bool ShootRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 8 && Vector3.Distance(transform.position, player.transform.position) >=7)
        {
            return true;
        }
        else
            return false;
    }
    private bool RetreetRange()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 7)
        {
            return true;
        }
        else
            return false;
    }
}
