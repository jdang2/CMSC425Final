using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPortalTutorial : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource open;
    public EnemyHP enemy;

    public Animator trigger;

    public Animator text;

    public Animator stencil;
    private bool one = true;
    void Start()
    {
        enemy = enemy.GetComponent<EnemyHP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.currentHealth.value <= 0 && one){
            PlaySound();
        }
    }


    void PlaySound(){
        open.Play();
        trigger.SetTrigger("start");
        stencil.SetTrigger("start");
        one = false;
        StartCoroutine(Delay());
    }


    IEnumerator Delay(){
        text.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        text.SetTrigger("end");
    }
}
