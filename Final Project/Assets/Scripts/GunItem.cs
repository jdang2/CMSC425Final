using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : Interactable
{
    // Start is called before the first frame update
    public override void trigger()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
}
