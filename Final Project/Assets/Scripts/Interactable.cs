using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public virtual void trigger(){
        Debug.Log("Interactable Triggered");
    }
}
