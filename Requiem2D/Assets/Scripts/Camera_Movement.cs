using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {
    GameObject shark;

    // Start is called before the first frame update
    void Start () {
        shark = GameObject.Find ("Shark");
    }

    // Update is called once per frame
    //Camera follows player
    void Update () {
        transform.position = new Vector3(shark.transform.position.x, shark.transform.position.y, -10.0f);
    }
}