using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAddHealth : MonoBehaviour
{
    
    public float heal = 1;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            col.GetComponent<Health>().TakeDamage(-heal);
            Destroy(gameObject);
        }
    }
}
