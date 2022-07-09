using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
    private Animator anim;
    private PlayerInputActions playerInput;
    private Vector2 moveInput;
 
    public AudioClip audioAttack;
    private AudioSource audio;
    
    void Awake() {
        playerInput = new PlayerInputActions();
        anim = gameObject.GetComponent<Animator>();
        playerInput.Movement.Attack.performed += ctx => AttackAnim();
        audio = GetComponent<AudioSource>();
    }

    void Start() {
        //ini jaga-jaga biar kgk tolol. Jadi gua declare pas start buat jaga2
        anim.SetBool("LookUp", false);
        anim.SetBool("LookDown", false);
        anim.SetBool("LookRight", true);
    }

    void FixedUpdate() {
        //Ini ngubah New input jadi Vector 2 buat dibaca animator dkk
        moveInput = playerInput.Movement.Move.ReadValue<Vector2>();

        //ini if else 3 biji ngatur bool liat kemana.
        //Gua bikin gini supaya dia bisa idle setelah jalan
        if (moveInput.x > 0.01f || moveInput.x < -0.01f) {

            if (!audio.isPlaying) {
                audio.Play();    
            }
            
            if(!anim.GetBool("LookRight")) { //gua nyimpen bool di animator controllernya

                anim.SetBool("LookUp", false);
                anim.SetBool("LookDown", false);
                anim.SetBool("LookRight", true);

            }

            //ini buat mirror animasi jalan ke kanan biar ngadep ke kiri
            if(moveInput.x < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            } else {
                transform.localScale = new Vector3(1, 1, 1);
            }

            anim.SetFloat("Horizontal", Mathf.Abs(moveInput.x));
            anim.SetFloat("Vertical", 0);

        } else if (moveInput.y > 0.01f) {
            
            if (!audio.isPlaying) {
                audio.Play();    
            }

            if(!anim.GetBool("LookUp")) {

                anim.SetBool("LookUp", true);
                anim.SetBool("LookDown", false);
                anim.SetBool("LookRight", false);

            }

            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", moveInput.y);
            
        } else if (moveInput.y < -0.01f) {

            if (!audio.isPlaying) {
                audio.Play();    
            }

            if(!anim.GetBool("LookDown")) {

                

                anim.SetBool("LookUp", false);
                anim.SetBool("LookDown", true);
                anim.SetBool("LookRight", false);

            }

            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", moveInput.y);
        }


        //ini funky ass sih tapi kalo kgk ada if ini float value di animatornya nyangkut
        if (moveInput.x == 0f && moveInput.y == 0f) {
            anim.SetFloat("Horizontal", 0);
            anim.SetFloat("Vertical", 0);
        }

    }

    public void DeathAnim() {
        anim.SetTrigger("Dead");
    }

    private void AttackAnim() {
        anim.SetTrigger("Attack");
        audio.PlayOneShot(audioAttack);
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    public void OnDisable() {
        playerInput.Disable();
    }

}
