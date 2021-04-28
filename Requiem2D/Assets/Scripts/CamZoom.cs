using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    Camera cam;
    public float camSize;
    public float sharkSize;
    public float zoomConstant;
    GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        shark = GameObject.Find("Shark");
        sharkSize = shark.GetComponent<Movement> ().scale;;
        cam.orthographic = true;
        camSize = sharkSize * zoomConstant;
        cam.orthographicSize = camSize;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
