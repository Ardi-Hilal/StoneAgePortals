using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayScene : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        StartCoroutine(WaitToLoadScene());
    }

    private IEnumerator WaitToLoadScene()
    { 
        yield return new WaitForSeconds(3); 
        SceneManager.LoadScene(sceneName);
    }
}
