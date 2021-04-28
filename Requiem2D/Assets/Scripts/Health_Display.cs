using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Display : MonoBehaviour
{
    Text healthDisplay;
    vitalBars script;
    float health;
    float maxHealth;
    Color displayColor;
    float ratio;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find ("Healthbar filled").GetComponent<vitalBars> ();
        maxHealth = script.maxValue;
        healthDisplay = GetComponent<Text>();
        displayColor = new Color (0.0f, 255f, 255f);
    }

    // Update is called once per frame
    void Update()
    {
        //Changes bar color based on fill amount and displays health
        ratio = health/maxHealth;
        displayColor = Color.HSVToRGB (ratio / 2, 1.0f, 1.0f);
        health = script.value;
        healthDisplay.text = health.ToString("F1");
        GetComponent<Text>().color = displayColor;
    }
}
