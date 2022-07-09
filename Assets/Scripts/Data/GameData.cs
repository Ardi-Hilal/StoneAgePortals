using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    
    //ini ngatur health playernya
    public float heroHealth = 3;
    private bool isDead = false;
    public GameObject loseUI;

    public int lastSceneIndex;
    public Vector3 lastSceneLocation;
    public GameObject player;

    void Awake() {

        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;

            //DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckPlayer() {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Ngecek ulang prefab player");
    }

    void Update() {
        if (heroHealth <= 0 && !isDead) {
        isDead = true;
        LoseCondition();
        }
    }

    public void LoseCondition() {

        player.GetComponent<PlayerController>().OnDisable();

        foreach(SpriteDirection sprite in player.GetComponentsInChildren<SpriteDirection>()) {
            sprite.enabled = false;
        }

        foreach(Animator anim in player.GetComponentsInChildren<Animator>()) {
                anim.SetBool("Dead", true);
                anim.SetFloat("Horizontal", 0);
                anim.SetFloat("Vertical", 0);
        }

        Cursor.visible = true;
        loseUI.SetActive(true);

    }

    public void Reset() {
        player.GetComponent<PlayerController>().OnEnable();

        foreach(SpriteDirection sprite in player.GetComponentsInChildren<SpriteDirection>()) {
            sprite.enabled = true;
        }
    }
}
