using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predatorHealth : MonoBehaviour {
    public float health;
    public float healthConst;
    public float foodConst;
    public float armor;
    float damage;
    float foodValue;
    float biteSize;
    Player_Animations script;
    PlayerStats playerStats;
    BasicPredatorScript behaviorScript;
    FoodBar script2;
    Rigidbody2D rb;
    GameObject player;
    bool bite;
    bool inRange;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        playerStats = GameObject.Find ("Shark").GetComponent<PlayerStats> ();
        script = GameObject.Find ("Shark").GetComponent<Player_Animations> ();
        behaviorScript = this.GetComponent<BasicPredatorScript> ();
        script2 = GameObject.Find ("Foodbar filled").GetComponent<FoodBar> ();
        foodValue = foodConst * behaviorScript.scale;
        health = healthConst * behaviorScript.scale;
        inRange = false;
        damage = playerStats.attack;
        biteSize = 2f * damage;
    }

    // Update is called once per frame
    void Update () {
        bite = script.bite;
        if (health <= 0) {
            MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour> ();
            foreach (MonoBehaviour c in scripts) {
                if (c != this) {
                    c.enabled = false;
                }
            }
            if (foodValue <= 0) {
                Destroy (gameObject);
            }
        }
        if (inRange) {
            if (bite) {
                health -= damage;
                if (health <= 0 && foodValue > 0) {
                    if (foodValue / biteSize >= 1) {
                        script2.food += biteSize;
                    } else {
                        script2.food += foodValue / biteSize;
                    }
                    foodValue -= biteSize;
                }
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Jaws")) {
            inRange = true;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Jaws")) {
            inRange = false;
        }
    }
}