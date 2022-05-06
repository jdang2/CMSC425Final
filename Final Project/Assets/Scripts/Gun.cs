using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float interactRange = 1f;
    public AudioSource enemyHitSound = null;
    public AudioSource shot;

    public float maxZoom = 10f;
    public float zoomSpeed = 500f;

    public bool isSniper = false;

    public ParticleSystem muzzleFlash; 
    public Camera fpsCam;
    public MouseLook mouseLook;

    public float fireRate = 15f;

    private float nextTimeToFire = 0f;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    

    public Slider ammo;

    private float timeToWaitForKeyInput = 0.1f;
    private float timeSinceOpened = 0.2f;
    void Start(){
        StartCoroutine(Interact());
        shot = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && ammo.value >= 1 && FindObjectOfType<GameManager>().gameHasEnded == false){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

        if(ammo.value != 3){
            ammo.value = ammo.value + Time.deltaTime/3;
        }
        timeSinceOpened = timeSinceOpened + Time.deltaTime;

        if(isSniper && Input.GetMouseButton(1) && fpsCam.fieldOfView > maxZoom){
            fpsCam.fieldOfView = fpsCam.fieldOfView - zoomSpeed * Time.deltaTime;
            mouseLook.mouseSensitivty = 1f;
        }

        if(fpsCam.fieldOfView < 60 && !Input.GetMouseButton(1)){
            fpsCam.fieldOfView = fpsCam.fieldOfView + zoomSpeed * Time.deltaTime;
            mouseLook.mouseSensitivty = 3f;
        }
    }

    IEnumerator Interact(){
        
        while(true){
            RaycastHit hit; 
            

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, interactRange)){
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                

                if(interactable != null && hit.distance <= 0.75f && timeSinceOpened >= timeToWaitForKeyInput){
                    timeSinceOpened = 0;
                    Debug.Log(hit.distance);
                    interactable.trigger();
                }
            }
        }
    }

    

    void Shoot(){
        
        ammo.value = ammo.value - 1;
        muzzleFlash.Play();
        shot.Play();
        RaycastHit hit; 
        

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            
            EnemyHP enemy = hit.transform.GetComponent<EnemyHP>();
            float dmgCalc = damage;
            if(!isSniper){
                dmgCalc = dmgCalc/hit.distance;
            }
            if(enemy != null){
                enemy.TakeDamage(dmgCalc);
                enemyHitSound.pitch = 15/dmgCalc;
                enemyHitSound.Play();
            }

            
        }
    }
    
}
