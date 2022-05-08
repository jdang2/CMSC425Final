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
    private int waveSpawners;

    public GameObject deathAni;
    
    public bool canAttack = true;

    public GameObject winScreen;

    

    void Start(){
        attackOne = GameObject.Find("WalkerSpawner").GetComponent<BossSpawnsEnemies>();
        waveSpawners = attackTwo.transform.childCount;
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
        GameObject[] walkers;
        walkers = GameObject.FindGameObjectsWithTag("Boss Spawns");
        for(int i = 0; i < walkers.Length; i++){
            Destroy(walkers[i].gameObject);
        }
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
                Transform nearestWave = attackTwo.transform.GetChild(0);
                for (int value = 1; value < waveSpawners; value ++) {
                    Transform temp = attackTwo.transform.GetChild(value);
                    if(Vector3.Distance(transform.position, temp.position) < Vector3.Distance(transform.position, nearestWave.position)){
                        nearestWave = temp;
                    }
                }

                nearestWave.gameObject.GetComponent<WaveSpawner>().SpawnWave();
            }
            yield return new WaitForSeconds(4);
        }
    }
}
