using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
