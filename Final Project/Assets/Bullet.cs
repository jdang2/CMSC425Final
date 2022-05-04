using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision target){
        if(target.gameObject.tag == "player"){
            Destroy(gameObject);
        }else{
            Destroy(gameObject, 1f);
        }
    }
}
