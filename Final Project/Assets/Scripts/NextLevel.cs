using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Animator trigger;

    public Animator bartrigger;

    public Animator cdTrig;
    public float transitionTime = 2f;
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "player")
        {
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    IEnumerator Load(int index){
                 
        trigger.SetTrigger("start");
        bartrigger.SetTrigger("dead");
        cdTrig.SetTrigger("end");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}



 