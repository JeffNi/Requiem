using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    public float delay;
    Animator animator;
    vitalBars healthScript;
    public bool bite;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthScript = GameObject.Find ("Healthbar filled").GetComponent<vitalBars>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bite) {
            delay = 0.2f;
        }
        delay -= 0.01f;
        if (healthScript.value <= 0) {
            dead = true;
        }
        bite = Input.GetKeyDown(KeyCode.K) &&  (delay <= 0);
        bool speeding = Input.GetKey(KeyCode.J);
        bool swimming = ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)));
        animator.SetBool("Biting", bite);
        animator.SetBool("Boosting", speeding);
        animator.SetBool("Swimming", swimming);
    }
}
