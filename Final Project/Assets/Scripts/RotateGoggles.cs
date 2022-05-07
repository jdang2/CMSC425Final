using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGoggles : MonoBehaviour
{

    private Vector3 pos1;
    private Vector3 pos2;

    public float yOffset;

    public float moveSpeed = 0.05f;

    public bool rotate = true;
    public bool bob = true;

    private Vector3 moveTo;

    
    void Start()
    {

        pos1 = transform.position;
        pos2 = transform.position + new Vector3(0, yOffset, 0); 
    }

    void FixedUpdate()
    {   
        if(rotate){
            transform.Rotate(Vector3.up * 15 * Time.deltaTime, Space.World);
        }
        if(transform.position == pos1)
        {
            moveTo = pos2;
        }
        if(transform.position == pos2)
        {
            moveTo = pos1;
        }
        if(bob){
            transform.position = Vector3.MoveTowards(transform.position, moveTo, moveSpeed * Time.deltaTime);
        }
    }
}
