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

    private GameObject end;
    private float nextTimeToFire = 0f;
    private LineRenderer laser;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource shot;

 
    void Start(){
        end = GameObject.Find("GunEnd");
        laser = GetComponent<LineRenderer>();
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
        //StartCoroutine(ShotEffect());
        // ParticleSystem temp = Instantiate(muzzleFlash);
        // temp.transform.SetParent(end.transform, false);
        // temp.Play();
        
        muzzleFlash.Play();
        shot.Play();
        RaycastHit hit; 
        

        //laser.SetPosition(0, end.transform.position);

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
            //laser.SetPosition(1, hit.point);

            
        }
        else{
            //laser.SetPosition(1, rayOrigin + (fpsCam.transform.forward * range));
        }
    }
    
    private IEnumerator ShotEffect(){
        laser.enabled = true;
        yield return shotDuration;
        laser.enabled = false;
    }
}
