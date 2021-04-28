using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    GameObject shark;
    Light sun;
    float intensity;
    float depth;
    public float maxDepth = 300f;

    // Start is called before the first frame update
    void Start()
    {
        shark = GameObject.Find("Shark");
        sun = GetComponent<Light>();
        depth = shark.transform.position.y;
        sun.GetComponent<Light>().intensity = 1.25f;
    }

    // Update is called once per frame
    void Update()
    {
        depth = shark.transform.position.y;
        sun.GetComponent<Light>().intensity = depth/(maxDepth/1.25f) + 1.25f;
    }
}
