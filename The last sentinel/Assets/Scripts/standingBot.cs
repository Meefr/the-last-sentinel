using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class standingBot : MonoBehaviour
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
            animator.SetBool("range", true);
       
        }

        else if (!animator.GetBool("died"))
        {
            animator.SetBool("range", false);
        }
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



    }

    private bool ShootRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 20 )
        {
            return true;
        }
        else
            return false;
    }
   
}
