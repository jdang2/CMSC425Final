using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForPlayer : MonoBehaviour
{


    public static int currentHealth = 100;

    private int saveHP;
    public PlayerHealthBar healthBar;

    public AudioSource deathSound;

    public AudioSource hitSound;

    public Animator wholeScreen;

    public Animator visionBar;

    public Animator objective;

    public Animator cooldownMSG;

    void Start()
    {
        saveHP = currentHealth;
        Debug.Log(currentHealth);
        healthBar.SetHealth(currentHealth);
        healthBar.SetMaxHealth(100);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
        if(healthBar.slider.value <= 0){
            wholeScreen.SetTrigger("start");
            visionBar.SetTrigger("dead");
            cooldownMSG.SetTrigger("end");
            objective.SetTrigger("leave");
            deathSound.Play();
            FindObjectOfType<GameManager>().EndGame();
            currentHealth = saveHP;
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

    public void setCurrentHealth(int amount){
        currentHealth = amount;
    }

    public void heal(int amount){
        currentHealth += amount;
        if(currentHealth > 100){
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
    }
}
