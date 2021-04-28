using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColor : MonoBehaviour
{
    GameObject shark;
    float depth;
    float percent;
    public float maxDepth = 625f;
    Color skyCol;
    Camera cam;
    const float red = 78f/255f;
    const float green = 192f/255f;
    const float blue = 239f/255f;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        shark = GameObject.Find("Shark");
        depth = shark.transform.position.y;
        skyCol = new Color (red, green, blue);
        cam.backgroundColor = skyCol;
    }

    // Update is called once per frame
    void Update()
    {
        depth = shark.transform.position.y;
        percent = (maxDepth + depth)/maxDepth;
        skyCol = new Color (percent * red, percent * green, percent * blue);
        cam.backgroundColor = skyCol;
    }
}
