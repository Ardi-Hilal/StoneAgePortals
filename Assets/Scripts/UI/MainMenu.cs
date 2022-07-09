using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Cutscene");
    }

}
