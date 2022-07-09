using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarimauPatrolHorizontal : MonoBehaviour
{
    public float speed;

    [HideInInspector]
    public bool mustPatrol;

    public Rigidbody2D rb;

    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }

    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }


    void Patrol()
    {
        if(bodyCollider.IsTouchingLayers(groundLayer)) 
        {
            Flip();
        }

        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y); 
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true;
    }
}
