using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody rigidbody;
    public Camera mainCamera;
    public float m_Speed = 10f;
    public float m_Lifespan = 3f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(rigidbody.transform.forward * m_Speed);
        Destroy(gameObject, m_Lifespan);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
