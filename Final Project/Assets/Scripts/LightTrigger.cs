using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject lights;
    
    void OnTriggerEnter(Collider other){
        if(lights.activeSelf == false){
            lights.SetActive(true);
        }
    }
}
