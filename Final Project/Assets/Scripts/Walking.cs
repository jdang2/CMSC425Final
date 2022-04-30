using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    CharacterController control;

    private AudioSource walk;
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
        walk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(control.isGrounded && walk.isPlaying == false){
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            
                walk.Play();
        }
    }
}
