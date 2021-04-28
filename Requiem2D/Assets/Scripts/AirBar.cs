using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBar : MonoBehaviour {
    public float air;
    public float maxAir;
    public float drainSpeed;
    float ratio;
    GameObject player;
    float playerHeight;
    public bool gillPump;
    Color barColor;

    // Start is called before the first frame update
    void Start () {
        player = GameObject.Find ("Shark");
        barColor = new Color (1f, 1f, 1f);
        drainSpeed = 0.25f;
        GetComponent<Image> ().fillAmount = 1.0f;
        GetComponent<Image> ().color = barColor;
        air = maxAir;
    }

    // Update is called once per frame
    void Update () {
        playerHeight = player.transform.position.y;
        ratio = air / maxAir;
        GetComponent<Image> ().fillAmount = ratio;
        barColor = Color.HSVToRGB (0.53f, 1.0f - ratio, 1.0f);
        GetComponent<Image> ().color = barColor;
        if (((Input.GetKey (KeyCode.D)) || (Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.S)) || (Input.GetKey (KeyCode.W)) || (gillPump == true)) && playerHeight <= 0) {
            if (air < maxAir) {
                air++;
            }
        } else {
            air -= drainSpeed;
        }
        if (air < 0) {
            air = 0;
        }
    }
}