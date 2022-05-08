using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public HealthForPlayer player;
    public int damage = 10;
    public bool isAttack = true;

    public AudioSource hitPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<HealthForPlayer>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other){
        if(other.name == "Player"){
            Debug.Log("Collision with player");
            player.TakeDamage(damage);
            if(isAttack && hitPlayer != null){
                hitPlayer.Play();
            }
        }
    }
}
