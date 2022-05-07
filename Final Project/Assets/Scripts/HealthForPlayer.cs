using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForPlayer : MonoBehaviour
{

    public int maxHealth = 100;

    public static int currentHealth = 100;

    private int saveHP;
    public PlayerHealthBar healthBar;

    public AudioSource deathSound;

    public AudioSource hitSound;

    public Animator wholeScreen;

    public Animator visionBar;

    public Animator objective;

    public Animator cooldownMSG;

    // Start is called before the first frame update
    void Start()
    {
        saveHP = currentHealth;
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
      
        
    }

    void Update(){
        
    }

    // Update is called once per frame

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(healthBar.slider.value <= 0){
            currentHealth = saveHP;
            wholeScreen.SetTrigger("start");
            visionBar.SetTrigger("dead");
            cooldownMSG.SetTrigger("end");
            objective.SetTrigger("leave");
            deathSound.Play();
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Enemy" && target.gameObject.name != "bullet"){
            hitSound.Play();
            TakeDamage(10);
        }else if(target.gameObject.tag == "Enemy" && target.gameObject.name == "bullet"){
            hitSound.Play();
            TakeDamage(5);
        }
    }

    public int GetCurrentHealth(){
        return currentHealth;
    }
}
