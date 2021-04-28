using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour {

    float x = 0;
    float y = 0;
    float v = 0;

    // Start is called before the first frame update
    void Start () {
        transform.position = new Vector3 (transform.position.x, 10.0f, transform.position.z);
    }

    // Update is called once per frame
    void Update () {
        /*
        if (x < 280) {
            transform.position = new Vector3 (transform.position.x, Mathf.Cos (x * Mathf.Deg2Rad) * 6f + 4.5f, transform.position.z);
            x += 0.7f;;
        } else {
            transform.position = new Vector3 (transform.position.x, Mathf.Sin (y * Mathf.Deg2Rad) * 0.4f - 0.75f, transform.position.z);
            y += 0.4f;
        }*/
        transform.position = new Vector3 (transform.position.x, transform.position.y - v, transform.position.z);
        if (transform.position.y > 1.66) {
            v += (0.0005f - x);
        } else {
            v -= (0.001f - x);
            x += 0.0001f;
        }

    }
}