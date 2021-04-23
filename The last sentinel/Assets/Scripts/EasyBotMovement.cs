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
        if (ShootRange())
        {
            animator.SetBool("run", false);
            stop();
        }
        else if (RetreetRange())
        {
            animator.SetBool("run", true);
            moveBackward();
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 10)
        {
            animator.SetBool("run", true);
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
        Vector3 destination = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z + 2);
        navMeshAgent.SetDestination(destination);
    }
    private void stop()
    {
        navMeshAgent.SetDestination(transform.position);
    }
    private bool ShootRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 8 && Vector3.Distance(transform.position, player.transform.position) >= 7)
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
