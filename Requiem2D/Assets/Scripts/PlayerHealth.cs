using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    Rigidbody2D rb;
    float damage;
    BasicPredatorScript enemyScript;
    vitalBars healthScript;
    Animations enemyAnimations;
    public bool inRange = false;
    bool coroutine;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        healthScript = GameObject.Find ("Healthbar filled").GetComponent<vitalBars> ();
    }

    // Update is called once per frame
    void Update () {
        if (inRange) {
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("DamageDealer")) {
            inRange = true;
        }
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.CompareTag ("DamageDealer")) {
            enemyAnimations = other.gameObject.transform.parent.gameObject.GetComponent<Animations> ();
            enemyScript = other.gameObject.transform.parent.gameObject.GetComponent<BasicPredatorScript> ();
            damage = enemyScript.damage;
            if (enemyAnimations.delay <= 0) {
                healthScript.value -= damage;
                enemyAnimations.delay = enemyAnimations.attackTime;
                healthScript.takingDmg = 2;
                coroutine = true;
            }
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("DamageDealer")) {
            inRange = false;
        }
    }

    IEnumerator waitTime (float t) {
        while (coroutine) {
            yield return new WaitForSeconds (t);
            coroutine = false;
        }
    }
    void hurtPlayer () {
        enemyAnimations.delay = 1;
    }
}