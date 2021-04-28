using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChange : MonoBehaviour
{
    GameObject mapSlider;
    float val;
    // Start is called before the first frame update
    void Start()
    {
        mapSlider = GameObject.Find ("Slider");
    }

    // Update is called once per frame
    void Update()
    {
        val = mapSlider.GetComponent<Slider>().value;
        transform.position = new Vector3(transform.position.x, transform.position.y, val*10f);
    }
}
