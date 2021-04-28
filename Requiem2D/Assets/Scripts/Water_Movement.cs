using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Movement : MonoBehaviour {
    GameObject shark;

    // Start is called before the first frame update
    void Start () {
        shark = GameObject.Find ("Shark");
    }

    // Update is called once per frame
    void Update () {
        //Follows player
        //I didn't create the water but edited another script so that the water rises and falls
        transform.position = new Vector3 (shark.transform.position.x, shark.transform.position.y, -3.0f);
    }
}