using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEnemyHP : MonoBehaviour
{

    public EnableVision status;

    public GameObject enemyHP;

    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        if(status.visionOn){
            enemyHP.SetActive(true);
        }else{
            enemyHP.SetActive(false);
        }
        
    }

    void LateUpdate(){
        transform.LookAt(transform.position + cam.forward);
    }
}
