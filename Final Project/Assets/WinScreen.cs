using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public Animator trigger;

    public Animator barTrigger;
    public GameObject otherUI;
    public GameObject gun;
    
    // Start is called before the first frame update
    void Start()
    {
        otherUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        gun.GetComponent<Gun>().enabled = false;
        AudioListener.pause = true;
    }

    public void PlayAgain(){
        SceneManager.LoadScene(0);
    }
    public void Quit(){
        Application.Quit();
    }


}
