using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public Slider playerHP;
    public AudioSource bandageTear;
    public bool isTutorial = false;

   
    void OnTriggerEnter(Collider target){
        if(target.tag == "Healthpack" && (playerHP.value < 100 || isTutorial))
        {
            bandageTear.Play();

            playerHP.value += 20;
        }
    }
}
