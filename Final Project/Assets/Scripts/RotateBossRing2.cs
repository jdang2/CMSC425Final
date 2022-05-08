using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBossRing2 : MonoBehaviour
{
    // Start is called before the first frame update
    float rotationsPerMinute = 12f;

    void Update()
    {
        transform.Rotate(-6.0f*rotationsPerMinute*Time.deltaTime, 0f ,0f);
    }
}
