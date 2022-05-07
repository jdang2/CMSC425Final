using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public Transform cam;

    public Slider bossHP;

    public GameObject boss;
    private int RNG;

    public BossSpawnsEnemies attackOne;



    void Start(){
        attackOne = GameObject.Find("WalkerSpawner").GetComponent<BossSpawnsEnemies>();
     
        StartCoroutine(Attack());
    }
    void LateUpdate(){
        transform.LookAt(transform.position + cam.forward);
        
    }

    IEnumerator Attack(){
        while(true){
            RNG = Random.Range(0, 10);
            Debug.Log("Coroutine rolled a " +  RNG);
            if(RNG >= 6){
                //attackOne.SpawnEnemies();
              
            }else{
                
            }
            yield return new WaitForSeconds(3);
        }
    }
}
