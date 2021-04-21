using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anime : MonoBehaviour
{
    public Animator anim;
    public Camera maincam;
    public Camera backcam;
    public Camera dancecam;
    public Transform playerBody;
    public bool bl = false, bm=true;
    private Vector3 v, d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            anim.SetInteger("controllerr", 1);
        }
        else if (Input.GetKey("s"))
        {
            anim.SetInteger("controllerr", 2);
        }
        else if (Input.GetKey("d"))
        {
            anim.SetInteger("controllerr", 3);
        }
        else if (Input.GetKey("a"))
        {
            anim.SetInteger("controllerr", 4);
        }
        else if (Input.GetKey("q"))
        {
            anim.SetInteger("controllerr", 5);
        }
        else if (Input.GetKey("e"))
        {
            anim.SetInteger("controllerr", 6);
            dancecam.enabled = true;
            maincam.enabled = false;
            backcam.enabled = false;
        }
        else if (Input.GetKey("c"))
        {
            dancecam.enabled = false;
            if (bm)
            {
                bm = false;
                maincam.enabled = bl;
                backcam.enabled = !bl;
                bl = !bl;
            }
        }
        else
        {
            bm = true;
            anim.SetInteger("controllerr", 0);
        }
    }
}