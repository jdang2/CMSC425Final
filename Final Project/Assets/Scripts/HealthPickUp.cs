using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public Slider playerHP;

   
    void OnTriggerEnter(Collider target){
        if(target.tag == "Healthpack" && playerHP.value < 100)
        {
            playerHP.value += 10;
        }
    }
}
