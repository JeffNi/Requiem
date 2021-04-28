using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float baseHealth;
    public float baseAttack;
    public float attack;
    public float scale;
    public float foodConst;
    Movement moveScript;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.GetComponent<Movement> ();
        scale = moveScript.scale;
        attack = baseAttack * moveScript.scale;
    }

    // Update is called once per frame
    void Update()
    {
        //attack = baseAttack * moveScript.scale;
    }
}
