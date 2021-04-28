
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Rigidbody2D m_Rigidbody;
    public float cruiseSpeed;
    public float m_Speed;
    public float scale;
    float boostSpeed;
    float size;
    vitalBars script;
    float energy;
    public bool facingRight;
    public bool boosting;
    //var speed = rigidbody.velocity.x; 

    // Start is called before the first frame update
    void Start () {
        size = this.transform.localScale.x;
        script = GameObject.Find ("Energybar filled").GetComponent<vitalBars> ();
        m_Rigidbody = GetComponent<Rigidbody2D> ();
        boostSpeed = cruiseSpeed * 1.5f;
        m_Speed = cruiseSpeed;
        facingRight = true;
        this.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        var speed = GetComponent<Rigidbody2D> ().velocity.x;
        energy = script.value;
        //Increases speed if there is energy and J key is held
        if ((Input.GetKey (KeyCode.J)) && (energy > 0)) {
            boosting = true;
            m_Speed = boostSpeed;
        } else {
            boosting = false;
            m_Speed = cruiseSpeed;
        }
        if (this.transform.position.y <= 0) {
            m_Rigidbody.gravityScale = 0.0f;
            if (Input.GetKey (KeyCode.D)) {
                //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
                m_Rigidbody.velocity = transform.right * m_Speed * size;
                if (!facingRight) {
                    facingRight = true;
                    transform.localScale = new Vector3(scale,scale,1); 
                }
            }
            if (Input.GetKey (KeyCode.A)) {
                //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
                m_Rigidbody.velocity = -transform.right * m_Speed * size;
                if (facingRight) {
                    facingRight = false;
                    transform.localScale = new Vector3(-scale,scale,1); 
                }
            }
        } else {
            //Prevents going above water
            m_Rigidbody.gravityScale = 6.0f;
        }

        if (Input.GetKey (KeyCode.W)) {
            //rotate the sprite about the Z axis in the positive direction
            if (facingRight && (transform.rotation.eulerAngles.z < 80 || transform.rotation.eulerAngles.z > 260)) {
                transform.Rotate (new Vector3 (0, 0, 3) * Time.deltaTime * m_Speed, Space.World);
            } else if (transform.rotation.eulerAngles.z > 280 || transform.rotation.eulerAngles.z < 100) {
                transform.Rotate (new Vector3 (0, 0, -3) * Time.deltaTime * m_Speed, Space.World);
            }
        }

        if (Input.GetKey (KeyCode.S)) {
            //rotate the sprite about the Z axis in the negative direction
            if (facingRight && (transform.rotation.eulerAngles.z < 100 || transform.rotation.eulerAngles.z > 280)) {
                transform.Rotate (new Vector3 (0, 0, -3) * Time.deltaTime * m_Speed, Space.World);
            } else if (transform.rotation.eulerAngles.z < 80 || transform.rotation.eulerAngles.z > 260) {
                transform.Rotate (new Vector3 (0, 0, 3) * Time.deltaTime * m_Speed, Space.World);
            }
        }

        if (facingRight) {
            //Sets maximum and minimum rotation
            if (transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 180) {
                transform.rotation = Quaternion.Euler (0.0f, 0.0f, 80.0f);
            } else if (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 260) {
                transform.rotation = Quaternion.Euler (0.0f, 0.0f, 260.0f);
            }
        } else {
            if (transform.rotation.eulerAngles.z > 100 && transform.rotation.eulerAngles.z < 180) {
                transform.rotation = Quaternion.Euler (0.0f, 0.0f, 100.0f);
            } else if (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 280) {
                transform.rotation = Quaternion.Euler (0.0f, 0.0f, 280.0f);
            }
        }
    }
}