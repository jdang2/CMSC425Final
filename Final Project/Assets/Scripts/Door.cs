using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public float startAngle;
    public float openAngle;
    public float openSpeed = 1;
    private float endAngle;

    private bool isOpen = false;


    void Start(){
        startAngle = transform.rotation.y;
        endAngle = startAngle + openAngle;
    }

    public override void trigger()
    {
        isOpen = !isOpen;
        
    }
    void Update(){
        if(transform.rotation.y != endAngle && isOpen){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, endAngle, 0), openSpeed * Time.deltaTime);
        }
        if(transform.rotation.y != startAngle && !isOpen){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, startAngle, 0), openSpeed * Time.deltaTime);
        }
    }
    
}
