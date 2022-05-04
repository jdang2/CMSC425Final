using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableVision : MonoBehaviour
{
    public GameObject window;
    private float timeSinceOpened = 0.2f;
    private float timeToWaitForKeyInput = 0.1f;
    private bool cooldownMSG = false;


    public bool visionOn = false;
    public AudioSource activation;

    public AudioSource off;

    public Slider visionSlider;
    public float disablePenalty = 0f;
    public float drainSpeed = 2f; 
    public float maxCharge = 7.5f;

    public Animator cdCheck;

    private float maxTime;

    private bool cooldown = false;
    [SerializeField] bool goggles = true;
    // Start is called before the first frame update
    void Start()
    {
        visionSlider.maxValue = maxCharge;
        visionSlider.value = maxCharge;
        maxTime = visionSlider.value;
        StartCoroutine(ToggleVision());
    }   

    // Update is called once per frame
    void Update()
    {
        if(window.activeSelf){
            visionSlider.value -= drainSpeed * Time.deltaTime;
        }else{
            visionSlider.value += Time.deltaTime;
        }

        if(visionSlider.value == 0){
            triggerCooldown();
        }

        if(visionSlider.value == maxTime && cooldown == true){
            cooldown = false;
            cooldownMSG = false;
            cdCheck.SetTrigger("end");
        }
    }

    
    void OnTriggerEnter(Collider target)
    {
        if(target.tag == "item")
        {
            visionOn = true;
            goggles = true;

            activation.Play();
            window.SetActive(true);
        }
    }

    void triggerCooldown(){
        window.SetActive(!window.activeSelf);
        cooldown = true;
        if(!cooldownMSG){
            cdCheck.SetTrigger("start");
            cooldownMSG = true;
        }
        visionOn = false;
        off.Play();
    }

    IEnumerator ToggleVision(){
        while(true){
            yield return null;
            timeSinceOpened = timeSinceOpened + Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Q) && (timeSinceOpened >= timeToWaitForKeyInput) && goggles){
                timeSinceOpened = 0f;

                if(cooldown == false){
                    window.SetActive(!window.activeSelf);
                    if(window.activeSelf){
                        visionOn = true;
                        off.Stop();
                        activation.Play();
                        
                    }else{
                        activation.Stop();
                        float val = visionSlider.value - disablePenalty;
                        if(val <= 0){
                            triggerCooldown();
                        }
                        visionSlider.value = val;
                        off.Play();
                        visionOn = false;
                    }
                }
            }
            
        }
    }
}
