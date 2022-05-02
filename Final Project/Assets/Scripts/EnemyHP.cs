using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount){
        currentHealth.value -= amount;
        if(currentHealth.value <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
