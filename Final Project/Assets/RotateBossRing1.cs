using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBossRing1 : MonoBehaviour
{
    float rotationsPerMinute = 12f;

    void Update()
    {
        transform.Rotate(6.0f*rotationsPerMinute*Time.deltaTime, 0f ,0f);
    }
}
