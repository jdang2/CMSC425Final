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
    
    private Gun checkIfSniper;

    public MeshFilter SniperMesh;
    public Material[] SniperMats;
    
    void Start(){
        checkIfSniper = GameObject.Find("Weapon").GetComponent<Gun>();
    }

 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && ammo.value >= 1){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if(checkIfSniper.isSniper){
            transform.gameObject.GetComponent<MeshFilter>().sharedMesh = SniperMesh.sharedMesh;
            transform.gameObject.GetComponent<Renderer>().materials = SniperMats;
        }

    }

    void Shoot(){
        
  
        muzzleFlash.Play();
   
    }
    
}
