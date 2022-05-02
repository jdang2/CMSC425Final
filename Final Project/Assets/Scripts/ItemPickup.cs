using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Animator trigger;


    void OnTriggerEnter(Collider target)
    {
        Debug.Log(trigger.name);
        if(target.tag == "player")
        {
            enemy.SetActive(true);
            Destroy(this.gameObject);
            trigger.SetTrigger("start");
            
        }
    }
}



