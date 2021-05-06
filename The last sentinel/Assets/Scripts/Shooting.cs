using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject bullet;
    private Transform player;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("Run") == false && animator.GetBool("range") == true)
        {
        if(timeBtwShots <= 0)
        {
                animator.SetBool("Shooting", true);
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            Instantiate(bullet, position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}
