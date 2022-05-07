using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Animator screenTrigger;

    public Animator bartrigger;

    public Animator cdTrig;

    public Animator objectiveTrig;
    public float transitionTime = 2f;


    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "player")
        {
            GameObject cdMSG = GameObject.Find("Cooldown");
            if(cdMSG != null){
                cdMSG.SetActive(false);
            }
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    IEnumerator Load(int index){
                 
        screenTrigger.SetTrigger("start");
        bartrigger.SetTrigger("dead");
        cdTrig.SetTrigger("end");
        objectiveTrig.SetTrigger("leave");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}



 