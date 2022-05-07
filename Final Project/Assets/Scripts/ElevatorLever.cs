using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLever : Interactable
{
    public float startAngle;
    public float onAngle;
    public float onSpeed = 1;

    public GameObject elevator;
    private float endAngle;

    private bool isOn = false;


    void Start(){
        
        endAngle = startAngle + onAngle;
    }

    public override void trigger()
    {
        isOn = !isOn;
        elevator.GetComponent<Elevator>().toggle();
    }

    void Update(){
        if(transform.rotation.z != endAngle && isOn){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, endAngle), onSpeed * Time.deltaTime);
        }
        if(transform.rotation.z != startAngle && !isOn){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, startAngle), onSpeed * Time.deltaTime);
        }
    }
    
}
