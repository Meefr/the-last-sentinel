using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animestate : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("back", true);
        }
        else
        {
            animator.SetBool("back", false);
        }
        if (Input.GetKey("d"))
        {
            animator.SetBool("right", true);
        }
        else
        {
            animator.SetBool("right", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("left", true);
        }
        else
        {
            animator.SetBool("left", false);
        }
    }
}
