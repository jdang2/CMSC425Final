using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public Animator trigger;
    public GameObject pauseMenu;
    public Animator barTrigger;
    public GameObject otherUI;
    public GameObject gun;
    public HealthForPlayer playerHP;
    
    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.Find("Player").GetComponent<HealthForPlayer>();
        otherUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gun.GetComponent<Gun>().enabled = false;
    }

    public void PlayAgain(){
        playerHP.setCurrentHealth(100);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Quit(){
        Application.Quit();
    }


}
