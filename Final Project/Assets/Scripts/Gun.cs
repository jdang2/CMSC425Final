using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

 
    void Start(){
    
        shot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot(){
        
        muzzleFlash.Play();
        shot.Play();
        RaycastHit hit; 
        

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);


            
        }
        else{
        
        }
    }
    
}
