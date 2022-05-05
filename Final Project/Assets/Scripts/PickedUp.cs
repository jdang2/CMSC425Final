using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickedUp : MonoBehaviour
{

    public HealthForPlayer player;

   

    void Start(){
        player = GameObject.Find("Player").GetComponent<HealthForPlayer>();
       
    }
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "player" && (player.GetCurrentHealth() < 100))
        {

            Destroy(gameObject);
        }
    }
}
