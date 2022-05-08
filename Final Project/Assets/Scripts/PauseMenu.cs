using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject otherUI;

    public GameObject cam;

    public GameObject gun;

    public Animator trigger;

    public Animator barTrigger;
    public GameObject pauseMenu;

    public HealthForPlayer playerHP;
    // Update is called once per frame

    void Start(){
        playerHP = GameObject.Find("Player").GetComponent<HealthForPlayer>();
    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        cam.GetComponent<MouseLook>().enabled = true;
        gun.GetComponent<Gun>().enabled = true;
         
        otherUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause(){
        Cursor.lockState = CursorLockMode.None;
        cam.GetComponent<MouseLook>().enabled = false;
        gun.GetComponent<Gun>().enabled = false;
        otherUI.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }   

    public void Menu(){
        playerHP.setCurrentHealth(100);
        Time.timeScale = 1f;
        StartCoroutine(Load(0));
    }

    public void Quit(){
        Application.Quit();
    }

    IEnumerator Load(int index){
        trigger.SetTrigger("start");
        barTrigger.SetTrigger("dead");
        otherUI.SetActive(true);

        yield return new WaitForSeconds(2f);
         
        SceneManager.LoadScene(index);
    }
}


