using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPortal : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.forward * 15 * Time.deltaTime); 
    }
}
