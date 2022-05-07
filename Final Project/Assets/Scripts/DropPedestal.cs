using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPedestal : MonoBehaviour
{
    private Vector3 dropPos;

    public float yOffset;

    public float moveSpeed = 0.05f;

    public bool drop = false;

    public GameObject Boss;

    public ParticleSystem spawnParticles;

    public AudioSource bossSpawnNoise;
    
    void Start()
    {
        dropPos = transform.position + new Vector3(0, yOffset, 0); 
    }

    public void Drop(){
        drop = true;
    
    }

    void FixedUpdate()
    {   
        if(drop)
        {
           transform.position = Vector3.MoveTowards(transform.position, dropPos, moveSpeed * Time.deltaTime);
        }
    }

    public void EnableBoss(){

        StartCoroutine(BossAwake());
    }

    IEnumerator BossAwake(){
        spawnParticles.Play();
        bossSpawnNoise.Play();
        yield return new WaitForSeconds(7);
        Boss.SetActive(true);
        bossSpawnNoise.Stop();
    }


    
}
