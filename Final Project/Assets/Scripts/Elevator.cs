using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private Vector3 pos1;
    private Vector3 pos2;

    public float yOffset;

    public float moveSpeed = 0.05f;

    public bool isOn = false;

    private Vector3 moveTo;

    
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + new Vector3(0, yOffset, 0); 
    }

    public void toggle(){
        isOn = !isOn;
    }

    void FixedUpdate()
    {   
        
        if(transform.position == pos1 && isOn)
        {
            moveTo = pos2;
        }
        if(transform.position == pos2 || !isOn)
        {
            if(!isOn){
                moveTo = pos1;
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, moveTo, moveSpeed * Time.deltaTime);
        
    }

    
}
