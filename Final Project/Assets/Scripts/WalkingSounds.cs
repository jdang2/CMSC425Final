using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    CharacterController control;


    public AudioSource walk = null;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(control.isGrounded && walk.isPlaying == false && FindObjectOfType<GameManager>().gameHasEnded == false){
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
                if(walk != null){
                    walk.Play();
                }
            }
        }
    }
}
