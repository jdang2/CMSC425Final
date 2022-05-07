using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPickup : Interactable
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Animator visionMeter;

    public TextMeshProUGUI text;


    public override void trigger()
    {
        
        enemy.SetActive(true);
        Destroy(this.gameObject);
        text.text = "- Shoot the enemy";
        visionMeter.SetTrigger("start");
            
    }
}



