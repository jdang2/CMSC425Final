using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Animator trigger;

    public TextMeshProUGUI text;


    void OnTriggerEnter(Collider target)
    {
        Debug.Log(trigger.name);
        if(target.tag == "player")
        {
            enemy.SetActive(true);
            Destroy(this.gameObject);
            text.text = "- Shoot the enemy";
            trigger.SetTrigger("start");
            
        }
    }
}



