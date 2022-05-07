using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunPickup : Interactable
{

    public GameObject Boss;

    public override void trigger()
    {
        DropPedestal parent = transform.parent.GetComponent<DropPedestal>();
        if(transform.parent != null){
            parent.Drop();
        }
        if(Boss != null){
            parent.EnableBoss();
        }
        Destroy(gameObject);
        
    }
}
