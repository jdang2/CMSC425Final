using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPortalLevels : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource openGateSound;
    public ProgressTrack progress;

    public Animator portalAnimation;

    public Animator textAnimation;

    public Animator stencilAnimation;
    private bool actionDone = false;

    // Update is called once per frame
    void Update()
    {
        if(progress.count == progress.objective && (!actionDone)){
            PlaySound();
        }
    }


    void PlaySound(){
        openGateSound.Play();
        portalAnimation.SetTrigger("start");
        stencilAnimation.SetTrigger("start");
        actionDone = true;
        StartCoroutine(Delay());
    }


    IEnumerator Delay(){
        textAnimation.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        textAnimation.SetTrigger("end");
    }
}
