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
    // public attackTwo;



    void Start(){
        attackOne = GameObject.Find("WalkerSpawner").GetComponent<BossSpawnsEnemies>();
     
        StartCoroutine(Attack());
    }
    void LateUpdate(){
        transform.LookAt(transform.position + cam.forward);
        
    }

    IEnumerator Attack(){
        while(true){
            RNG = Random.Range(1, 10);
            Debug.Log("Coroutine rolled a " +  RNG);
            if(RNG > 7){
                //attackOne.SpawnEnemies();
              
            }else{
                if(RNG > 3){
                    //attackTwo.SpawnWave();
                }
            }
            yield return new WaitForSeconds(3);
        }
    }
}
