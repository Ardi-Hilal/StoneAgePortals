using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private PlayerInputActions playerInput;
    [SerializeField] private AudioSource footstep; 

    private Rigidbody2D rb;

    [SerializeField] private float speed = 5f;

    void Awake() 
    {
        playerInput = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();   
    }

    public void OnEnable() {
        playerInput.Enable();
    }

    public void OnDisable() {
        playerInput.Disable();
    }

    void FixedUpdate() 
    {
       Vector2 moveInput = playerInput.Movement.Move.ReadValue<Vector2>();
       rb.velocity = moveInput * speed;
    }
}
