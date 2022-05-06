using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGoggles : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 15 * Time.deltaTime, Space.World);
    }
}
