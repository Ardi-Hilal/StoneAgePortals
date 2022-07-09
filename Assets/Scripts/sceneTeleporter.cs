using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTeleporter : Interactable
{
    public int sceneTarget;
    public bool saveLocation;

    public override void Interact() {
            
            // if (saveLocation) {
            //     GameData.instance.lastSceneLocation = other.gameObject.transform.position;
            // }
            
            //GameData.instance.heroHealth = other.gameObject.GetComponent<Health>().currHealth;
            GameData.instance.lastSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(sceneTarget);

    }
}
