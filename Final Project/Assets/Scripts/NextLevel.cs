using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public Animator trigger;
    public float transitionTime = 2f;
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "player")
        {
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    IEnumerator Load(int index){
        
        if(index == 2){
            trigger.SetTrigger("start");
        }else{
            trigger.SetTrigger("change");
        }
         

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}



 