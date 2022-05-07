using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wave;
    public GameObject parent;
    public float waveSpeed = 5f;
    private Transform child;
    private bool angleType;

    public bool trigger;

    void Start(){
        parent = GameObject.Find("WaveSpawners");
        if(transform.localPosition.z > 0){
            angleType = true;
        }else{
            angleType = false;
        }
    }

    public void SpawnWave(){
        child = Instantiate(wave, transform.position, Quaternion.identity, parent.transform).transform;
        child.gameObject.SetActive(true);
    }

    void Update(){
        if(trigger){
            trigger = false;
            SpawnWave();
        }
        if(child != null){
            child.Translate(waveSpeed * (parent.transform.position - transform.position) * Time.deltaTime);
            if(angleType && child.localPosition.z <= (-1 * transform.localPosition.z)){
                Debug.Log(child.localPosition.z);
                Debug.Log(-1 * transform.localPosition.z);
                Debug.Log("deleted");
                Destroy(child.gameObject);
            }else{
                if(!angleType && child.localPosition.z >= (-1 * transform.localPosition.z)){
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
