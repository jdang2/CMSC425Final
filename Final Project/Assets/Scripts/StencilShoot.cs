using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StencilShoot : MonoBehaviour
{

    public ParticleSystem muzzleFlash; 
    public Camera fpsCam;

    public float fireRate = 15f;

    public Slider ammo;
    private float nextTimeToFire = 0f;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && ammo.value >= 1){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }


    }

    void Shoot(){
        
  
        muzzleFlash.Play();
   
    }
    
}
