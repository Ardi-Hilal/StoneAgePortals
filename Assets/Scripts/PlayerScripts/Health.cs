using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{   
    [SerializeField] public float startingHealth;
    public float currHealth {get; private set; }
    public BoxCollider2D boxCollider;
    public UnityEvent TriggerEvent;

    // Start is called before the first frame update
    void Awake()
    {
        // if(gameObject.tag == "Player") {
        //     if (GameData.instance.heroHealth == 0) {
        //         currHealth = startingHealth;
        //     }
        //     else {
        //         currHealth = GameData.instance.heroHealth;
        //     }
        // }
        // else {
        //     currHealth = startingHealth;
        // }

        
    }

    public void TakeDamage(float _damage) {
        //currHealth = Mathf.Clamp(currHealth - _damage, 0, startingHealth);
        GameData.instance.heroHealth -= _damage;

    }

}
