using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction menu;
    
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pengaturanUI;

    // Start is called before the first frame update
    void Awake()
    {
       playerInputActions = new PlayerInputActions();
    }

    void Start() {
        Cursor.visible = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        pengaturanUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                   
    }

    private void OnEnable() 
    {
        menu = playerInputActions.Movement.Pause;
        menu.Enable();

        menu.performed += Pause;
    }

    private void OnDisable() 
    {
        menu.Disable();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            activateMenu();
        }
        else 
        {
            deactiveMenu();
        }
    }

    void activateMenu() 
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        pauseUI.SetActive(true);
    }

    public void deactiveMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        isPaused = false;
    }
    
    public void bukaPeng()
    {
        Time.timeScale = 0;
        pengaturanUI.SetActive(true);
        Cursor.visible = true;
    }

    public void tutupPeng()
    {
        Time.timeScale = 0;
        pengaturanUI.SetActive(false);
        Cursor.visible = true;
    }

    public void Hentikan()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void ToStage()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ToCut()
    {
        SceneManager.LoadScene("Cutscene");
    }

    public void Reset()
    {
        SceneManager.LoadScene("PuzzleStage1");
        Time.timeScale = 1;
    }

    

}
