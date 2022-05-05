using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewObjectives : MonoBehaviour
{
    public Animator objectiveAni;

    private float timeSinceOpened = 0.2f;
    private float timeToWaitForKeyInput = 0.1f;
    bool on = false;

    // Update is called once per frame

    void Start(){
        StartCoroutine(ToggleObjective());
    }

    IEnumerator ToggleObjective(){
        while(true){
            yield return null;
            timeSinceOpened = timeSinceOpened + Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Tab) && (timeSinceOpened >= timeToWaitForKeyInput)){
                timeSinceOpened = 0f;

                if(!on){
                    objectiveAni.SetTrigger("start");
                    on = true;
                }else{
                    objectiveAni.SetTrigger("end");
                    on = false;
                }
                 
            }
            
        }
    }
}
