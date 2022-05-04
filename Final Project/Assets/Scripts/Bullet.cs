using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject player;
    void Start(){
        player = GameObject.Find("Player");
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), player.GetComponent<Collider>());
        
    }
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision target){
        if(target.gameObject.tag == "player"){
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 2f);
        }
    }
}
