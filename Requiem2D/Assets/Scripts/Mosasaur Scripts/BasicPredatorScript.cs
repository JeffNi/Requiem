using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPredatorScript : MonoBehaviour {

    public float aggroRange;
    public float fightDistance;
    public float rotSpeed;
    public float speed;
    public float damageConst;
    public float damage;
    public float scale;
    public float velocity;

    float size;
    float playerSize;
    float distance;
    float rotation;
    float playerXPos;
    float xPos;

    int random;

    bool retreating;
    GameObject player;
    SpriteRenderer sprite;
    SpriteRenderer playerSprite;
    Rigidbody2D rb;
    Transform target;
    Vector3 difference;

    // Start is called before the first frame update
    void Start () {
        player = GameObject.Find ("Shark");
        rb = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
        playerSprite = player.GetComponent<SpriteRenderer> ();
        playerSize = playerSprite.bounds.extents.x;
        size = sprite.bounds.extents.x;
        distance = Vector3.Distance (player.transform.position, this.transform.position);
        target = player.GetComponent<Transform> ();
        this.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        damage = damageConst * scale;
        if (this.transform.position.y > 0) {
            this.GetComponent<Rigidbody2D> ().gravityScale = 10.0f;
        } else {
            this.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
        }
        xPos = this.transform.position.x;
        playerXPos = player.transform.position.x;
        difference = target.position - this.transform.position;
        target = player.GetComponent<Transform> ();
        distance = Vector3.Distance (player.transform.position, this.transform.position);
        if (distance < fightDistance) {
            Attack ();
        } else if (distance < aggroRange) {
            if (size >= (playerSize * 1.2f)) {
                Attack ();
            } else if (size * 1.2f <= playerSize) {
                Flee ();
            } else {
                Wander ();
            }
        } else {
            Wander ();
        }
    }

    void Wander () {

    }

    void Attack () {
        transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (difference), rotSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
        if (((playerXPos < (xPos + size * 0.5f)) && (playerXPos > (xPos - size * 0.5f))) || retreating == true) {
            Retreat ();
            if (distance > (size)) {
                retreating = false;
            } else {
                retreating = true;
            }
        } else if (playerXPos < xPos) {
            transform.localScale = new Vector3 (-scale, scale, 1);
            if (distance > (size * 1.2f)) {
                rb.velocity = -transform.right * speed;
            }
        } else if (playerXPos > xPos) {
            transform.localScale = new Vector3 (scale, scale, 1);
            if (distance > (size * 1.2f)) {
                rb.velocity = transform.right * speed;
            }
        }
    }

    void Flee () {

    }

    void Retreat () {
        if (retreating == false) {
            random = Random.Range (0, 2);
        }
        velocity = rb.velocity.magnitude;
        if (velocity < 3) {
            random = Random.Range (0, 2);
        }
        if (random == 0) {
            transform.localScale = new Vector3 (scale, scale, 1);
            rb.velocity = transform.right * speed;
        } else {
            transform.localScale = new Vector3 (-scale, scale, 1);
            rb.velocity = -transform.right * speed;
        }
    }
}