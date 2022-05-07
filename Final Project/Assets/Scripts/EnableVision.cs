using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableVision : MonoBehaviour
{
    public GameObject window;
    public GameObject nightVision = null;
    public GameObject spotLight = null;
    public Gun gun;
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
        nightVision = GameObject.Find("Directional Light");
        spotLight = GameObject.Find("Spot Light");
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

    public void pickupGoggles(){
        visionOn = true;
        goggles = true;

        activation.Play();
        window.SetActive(true);
        toggleNightVision(true);
    }

    public void pickupSniper(){
        gun.isSniper = true;
        gun.ammo.maxValue = 1;
        gun.ammo.value = 1;
        gun.damage = 20f;
        gun.shot.pitch = 0.3f;
        gun.range = 500f;
    }

    void triggerCooldown(){
        window.SetActive(false);
        toggleNightVision(false);
        cooldown = true;
        if(!cooldownMSG){
            cdCheck.SetTrigger("start");
            cooldownMSG = true;
        }
        visionOn = false;
        off.Play();
    }

    void toggleNightVision(bool state){
        if(nightVision != null){
            nightVision.SetActive(state);
        }
        if(spotLight != null){
            spotLight.SetActive(!state);
        }
    }

    IEnumerator ToggleVision(){
        while(true){
            yield return null;
            timeSinceOpened = timeSinceOpened + Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Q) && timeSinceOpened >= timeToWaitForKeyInput && goggles){
                timeSinceOpened = 0f;
                if(cooldown == false){
                    window.SetActive(!window.activeSelf);
                    toggleNightVision(window.activeSelf);
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
