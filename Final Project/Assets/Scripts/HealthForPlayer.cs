using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForPlayer : MonoBehaviour
{

    public int maxHealth = 100;

    public static int currentHealth = 100;

    private int saveHP;
    public PlayerHealthBar bar;

    public AudioSource death;

    public AudioSource hit;

    public Animator trigger;

    public Animator secondtrigger;

    public Animator cdTrigger;

    // Start is called before the first frame update
    void Start()
    {
        saveHP = currentHealth;
        Debug.Log(currentHealth);
        bar.SetHealth(currentHealth);
      
        
    }

    void Update(){
        
    }

    // Update is called once per frame

    void TakeDamage(int damage){
        currentHealth -= damage;
        bar.SetHealth(currentHealth);
        if(bar.slider.value <= 0){
            currentHealth = saveHP;
            trigger.SetTrigger("start");
            secondtrigger.SetTrigger("dead");
            cdTrigger.SetTrigger("end");
            death.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Enemy"){
            hit.Play();
            TakeDamage(10);
        }
    }
}
