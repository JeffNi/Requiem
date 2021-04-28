using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vitalBars : MonoBehaviour {
    public float maxValue;
    public float value;
    PlayerStats playerStats;
    FoodBar script;
    AirBar airScript;
    float air;
    float food;
    float ratio;
    Color barColor;
    public int takingDmg;

    // Start is called before the first frame update
    void Start () {
        playerStats = GameObject.Find ("Shark").GetComponent<PlayerStats> ();
        script = GameObject.Find ("Foodbar filled").GetComponent<FoodBar> ();
        airScript = GameObject.Find ("Airbar filled").GetComponent<AirBar> ();
        takingDmg = 0;
        if (gameObject.tag == "Health") {
            maxValue = playerStats.baseHealth * playerStats.scale;
            barColor = new Color (0.0f, 255f, 255f);
        } else if (gameObject.tag == "Energy") {
            barColor = new Color (255f, 255f, 0.0f);
        } else if (gameObject.tag == "Food") {
            barColor = new Color (255f, 0.0f, 0.0f);
        }
        value = maxValue;
        GetComponent<Image> ().fillAmount = 1.0f;
        GetComponent<Image> ().color = barColor;
    }

    // Update is called once per frame
    void Update () {
        ratio = value / maxValue;
        GetComponent<Image> ().fillAmount = ratio;
        if (gameObject.tag == "Health") {
            Health ();
        } else if (gameObject.tag == "Energy") {
            Energy ();
        }
    }

    void Health () {
        barColor = Color.HSVToRGB (ratio / 2, 1.0f, 1.0f);
        food = script.food;
        air = airScript.air;
        GetComponent<Image> ().color = barColor;
        StartCoroutine (waitTime (1.0f));
    }
    void Energy () {
        food = script.food;
        if ((Input.GetKey (KeyCode.J)) && (value > 0)) {
            value--;
        } else if (value < maxValue) {
            if (food > 0) {
                value += 0.4f;
            } else {
                value += 0.2f;
            }
        } else {
            value = maxValue;
        }
    }
    IEnumerator waitTime (float t) {
        if (takingDmg == 1) {
            yield return new WaitForSeconds (t);
            takingDmg = 0;
        }
        if (((air < 1)) && (value > 0)) {
            value -= 0.7f;
            takingDmg = 2;
        } else if (food < 1 && value > 0) {
            value -= 0.35f;
            takingDmg = 2;
        }
        else if ((value < maxValue) && (value > 0)) {
            takingDmg -= 1;
            value += 0.08f;
        }
        if (value > maxValue) {
            value = maxValue;
        }
        if (value < 0) {
            value = 0;
        }
    }
}