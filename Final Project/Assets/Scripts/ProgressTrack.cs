using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressTrack : MonoBehaviour
{

    public int count;
    public int objective;

    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCount(){
        count += 1;

        if(count == objective){
            text.text = "- Enter the Gate";
        }
    }
}
