using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRayCast : MonoBehaviour
{
    public GameObject interactIcon;
    
    private PlayerInputActions playerInput;
    private Vector2 moveInput;
    private Vector2 boxSize = new Vector2(1f, 1f); //buat ngatur size box raycastnya
    public float boxAdjustment = 0; //buat ngejauhin sama ngedeketin box raycastnya
    
    private float isUp = 0; //gua set ke 0 karena pengalaman gua C++ kalo kgk diset 0 dia bakal randomize angka awal
    private float isRight = 0; //gua set ke 0 karena pengalaman gua C++ kalo kgk diset 0 dia bakal randomize angka awal

    public float attackDamage;

    void Awake() 
    {
        playerInput = new PlayerInputActions();
        playerInput.Movement.Interactions.performed += ctx => CheckInteraction();
        playerInput.Movement.Attack.performed += ctx => PlayerAttack();
    }

    void FixedUpdate()
    {
        moveInput = playerInput.Movement.Move.ReadValue<Vector2>();

        // HAHAHA BISA AHAHAAHAHAH 3 HARI GUA NGERJAIN INI DOANG
        // ini if dibawah convert Vector 2 input ke float -1, 0, 1 buat nentuin arah raycast
        if (moveInput.y > 0.01f) {
            isUp = 1 + boxAdjustment;
            isRight = 0; //ini dibikin 0 supaya Raycastnya gak diagonal lokasinya dari player
        } else if (moveInput.y < -0.01f) {
            isUp = -1 - boxAdjustment;
            isRight = 0;
        }
        
        if (moveInput.x > 0.01f) {
            isRight = 1 + boxAdjustment;
            isUp = 0;
        } else if (moveInput.x < -0.01f) {
            isRight = -1 - boxAdjustment;
            isUp = 0;
        }

        NotifyInteractable();

        //Debug.Log(moveInput);
        
    }

    private void CheckInteraction(){
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + new Vector3(isRight, isUp, 0), boxSize, 0, Vector2.zero);

        if(hits.Length > 0) {
            foreach(RaycastHit2D rc in hits) {
                if (rc.transform.GetComponent<Interactable>()) {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }

    private void NotifyInteractable() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + new Vector3(isRight, isUp, 0), boxSize, 0, Vector2.zero);

        if(hits.Length > 0) {
            foreach(RaycastHit2D rc in hits) {
                if (rc.transform.GetComponent<Interactable>()) {
                   OpenInteractableIcon();
                } else {
                    CloseInteractableIcon();
                }
            }
        }
    }

    private void PlayerAttack() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position + new Vector3(isRight, isUp, 0), boxSize, 0, Vector2.zero);

        if(hits.Length > 0) {
            foreach(RaycastHit2D rc in hits) {
                if (rc.transform.GetComponent<EnemyHealth>()) {
                    rc.transform.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                    Debug.Log(attackDamage + " ke musuh");
                }
            }
        }
    }

    public void OpenInteractableIcon() {
        interactIcon.SetActive(true);
    }

    public void CloseInteractableIcon() {
        interactIcon.SetActive(false);
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(isRight, isUp, 0), boxSize);
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }
}
