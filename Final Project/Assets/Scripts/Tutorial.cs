using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider currentHealth;

    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            text.text = "- Enter the Gate";
        }
    }
}
