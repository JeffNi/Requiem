using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {
    Animator animator;
    PlayerHealth playerHP;
    public bool bite;
    public float attackTime;
    public float delay;
    float size;
    GameObject player;
    Transform jaw;
    bool coroutine;
    public bool close;

    // Start is called before the first frame update
    void Start () {
        delay = 0;
        player = GameObject.Find ("Shark");
        playerHP = player.GetComponent<PlayerHealth> ();
        animator = GetComponent<Animator> ();
        size = player.GetComponent<SpriteRenderer> ().bounds.extents.x;
        coroutine = true;
    }

    // Update is called once per frame
    void Update () {
        delay -= Time.deltaTime;
        jaw = this.transform.Find ("Jaws");
        close = playerHP.inRange;
        if (close && delay <= 0) {
            bite = true;
        } else {
            bite = false;
        }
        animator.SetBool("Biting", bite);
    } 

    IEnumerator waitTime (float t) {
        while (coroutine) {
            yield return new WaitForSeconds (t);
            coroutine = false;
        }
    }
}