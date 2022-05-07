using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : Interactable
{

    public GameObject Boss;

    public override void trigger()
    {
        if(transform.parent != null){
            DropPedestal parent = transform.parent.GetComponent<DropPedestal>();
            parent.Drop();
        }
        if(Boss != null){
            Boss.SetActive(true);
        }
        Destroy(gameObject);
        
    }
}
