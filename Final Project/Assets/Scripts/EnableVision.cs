using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVision : MonoBehaviour
{
    public GameObject window;
    private float timeSinceOpened = 0.2f;
    private float timeToWaitForKeyInput = 0.1f;

    public AudioSource activation;

    public AudioSource off;
    [SerializeField] bool goggles = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleVision());
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target)
    {
        Debug.Log("triggered");
        if(target.tag == "item")
        {
            goggles = true;
            activation.Play();
            window.SetActive(true);
        }
    }

    IEnumerator ToggleVision(){
        while(true){
            yield return null;
            timeSinceOpened = timeSinceOpened + Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Q) && (timeSinceOpened >= timeToWaitForKeyInput) && goggles){
                timeSinceOpened = 0f;
                window.SetActive(!window.activeSelf);
                if(window.activeSelf){
                    off.Stop();
                    activation.Play();
                     
                }else{
                    activation.Stop();
                    off.Play();
                }
            }
            
        }
    }
}
