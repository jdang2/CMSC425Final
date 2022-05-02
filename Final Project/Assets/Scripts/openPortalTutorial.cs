using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPortalTutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource open;
    public Enemy enemy;

    public Animator trigger;

    public Animator text;
    private bool one = true;
    void Start()
    {
        enemy = enemy.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.health <= 0 && one){
            PlaySound();
        }
    }


    void PlaySound(){
        open.Play();
        trigger.SetTrigger("start");
        one = false;
        StartCoroutine(Delay());
    }


    IEnumerator Delay(){
        text.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        text.SetTrigger("end");
    }
}
