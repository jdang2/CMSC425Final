using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public AudioSource bandageTear;
    public bool isTutorial = false;

    public HealthForPlayer playerHP;
   
    void Start(){
        playerHP = GameObject.Find("Player").GetComponent<HealthForPlayer>();
    }
    void OnTriggerEnter(Collider target){
        if(target.tag == "Healthpack" && (playerHP.GetCurrentHealth() < 100 || isTutorial))
        {
            bandageTear.Play();

            playerHP.heal(20);
        }
    }
}
