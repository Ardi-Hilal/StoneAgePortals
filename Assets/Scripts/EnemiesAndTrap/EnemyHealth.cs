using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float startingHealth;
    public float currHealth {get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        currHealth = startingHealth;
    }

    void Update() {
        if (currHealth <= 0) {
            Destroy (gameObject);
        }
    }

    public void TakeDamage(float _damage) {
        currHealth -= _damage;
        Debug.Log("Kena damage men " + _damage);
    }
}
