using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressTrack : MonoBehaviour
{

    public int count;
    public int objective;
    public bool isTutorial = false;

    public TextMeshProUGUI text;

    void Start(){
        if(!isTutorial){
            text.SetText("- Eliminate Enemies \n\t\t\t{0}/{1}", count, objective);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount(){
        count += 1;
        text.SetText("- Eliminate Enemies \n\t{0}/{1}", count, objective);

        if(count == objective){
            text.text = "- Enter the Gate";
        }
    }
}
