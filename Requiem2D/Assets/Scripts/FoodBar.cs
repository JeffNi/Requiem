using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour {
    public float maxFood;
    public float food;
    public float size;
    public float drainSpeed;
    PlayerStats playerStats;
    GameObject shark;
    vitalBars script;
    float energy;
    float maxEnergy;

    Color barColor = new Color (255f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start () {
        script = GameObject.Find ("Energybar filled").GetComponent<vitalBars> ();
        shark = GameObject.Find ("Shark");
        playerStats = shark.GetComponent<PlayerStats> ();
        size = playerStats.scale;
        maxFood = playerStats.foodConst * size;
        food = maxFood;
        drainSpeed = 0.1f;
        maxEnergy = script.maxValue;
        GetComponent<Image> ().fillAmount = 1.0f;
        GetComponent<Image> ().color = barColor;
    }

    // Update is called once per frame
    void Update () {
        energy = script.value;
        GetComponent<Image> ().fillAmount = food / maxFood;
        food = Mathf.Clamp(food, 0, maxFood);
        if ((energy < maxEnergy) && (!(Input.GetKey (KeyCode.J)))) {
            food -= drainSpeed * size * 2;
        }
        food -= drainSpeed * size;
    }
}