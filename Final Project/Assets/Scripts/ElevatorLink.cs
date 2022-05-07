using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLink : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other){
        if(other.gameObject.name == "Elevator"){
            transform.SetParent(other.transform);
        }
    }

    void OnCollisionExit(Collision other){
        if(other.gameObject.name == "Elevator"){
            transform.parent = null;
        }
    }
}
