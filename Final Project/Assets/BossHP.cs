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

    public GameObject attackTwo;

    public GameObject deathAni;
    
    public bool canAttack = true;

    public GameObject winScreen;

    

    void Start(){
        attackOne = GameObject.Find("WalkerSpawner").GetComponent<BossSpawnsEnemies>();
     
        StartCoroutine(Attack());
    }
    void LateUpdate(){
        if(bossHP.value > 0){
            transform.LookAt(transform.position + cam.forward);
        }else{
            Die();
        }
        
    }

    void Die(){
        canAttack = false;
        GameObject.Find("Boss group").GetComponent<RotateGoggles>().enabled = false;
        deathAni.SetActive(true);
        StartCoroutine(death());
    }

    IEnumerator death(){
        yield return new WaitForSeconds(5);
        Destroy(boss);
        winScreen.SetActive(true);
    }

    IEnumerator Attack(){
        while(canAttack){
            RNG = Random.Range(1, 11);
            if(RNG <= 3){
                attackOne.SpawnEnemies();
              
            }else if(5 <= RNG && RNG <= 7){
                int randomWave = Random.Range(0, attackTwo.transform.childCount);
                WaveSpawner currentWave = attackTwo.transform.GetChild(randomWave).GetComponent<WaveSpawner>();
                currentWave.SpawnWave();
            }else{
                //do no attack 
            }
            yield return new WaitForSeconds(4);
        }
    }
}
