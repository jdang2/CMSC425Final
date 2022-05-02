using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {
        Debug.Log("triggered");
        if(target.tag == "player")
        {
            enemy.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}



