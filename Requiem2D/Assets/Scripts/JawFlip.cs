using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawFlip : MonoBehaviour
{
    GameObject parent;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
        sprite = parent.GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        //Flips the position of the animal's jaws when the animal itself flips
       if (!sprite.flipX) {
           this.GetComponent<BoxCollider2D>().offset = new Vector2(4f, 0f);
       } else {
           this.GetComponent<BoxCollider2D>().offset = new Vector2(-2.55f, 0f);
       }
    }
}
