using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossProgressTrack : MonoBehaviour
{

   
    public Transform player;
    public GameObject boss;
    public TextMeshProUGUI text;

    void Start(){
        player = GameObject.Find("Player").transform;
        text.SetText("- Take the elevator");
        
    }
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > 49){
            text.SetText("- Pickup the Sniper Rifle");
        }
        if(boss.activeSelf == true){
            text.SetText("- Defeat Outer God");
        }
    }
}