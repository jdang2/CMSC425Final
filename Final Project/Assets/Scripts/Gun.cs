using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem muzzleFlash; 
    public Camera fpsCam;

    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource shot;

    public Slider ammo;
 
    void Start(){
    
        shot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && ammo.value >= 1){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if(ammo.value != 3){
            ammo.value = ammo.value + Time.deltaTime/3;
        }
    }

    void Shoot(){
        
        ammo.value = ammo.value - 1;
        muzzleFlash.Play();
        shot.Play();
        RaycastHit hit; 
        

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null){
                enemy.TakeDamage(damage);
            }

            
        }
    }
    
}
