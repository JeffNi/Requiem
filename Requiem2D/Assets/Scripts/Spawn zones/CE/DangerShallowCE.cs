using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerShallowCE : MonoBehaviour {
    public BoxCollider2D spawnZone;

    public GameObject mosasaur;

    const int mosaMax = 6;
    const float spawnInterval = 5f;

    float minX;
    float maxX;
    float minY;
    float maxY;

    float counter = 0;
    // Start is called before the first frame update
    void Start () {
        minX = spawnZone.offset.x;
        minY = spawnZone.offset.y;
        maxX = spawnZone.size.x + minX;
        maxY = spawnZone.size.y + minY;
    }

    // Update is called once per frame
    void Update () {
        if (counter <= 0) {
            float spawnCase = Random.Range (0f, 100f);
            if (spawnCase <= 3) {
                if (GameObject.FindGameObjectsWithTag ("Mosasaur").Length < mosaMax) {
                    Spawn (mosasaur);
                }
            }
            counter = spawnInterval;
        } else {
            counter -= Time.deltaTime;
        }
    }

    void Spawn (GameObject character) {
        float xPos;
        float yPos;
        xPos = Random.Range (minX, maxX);
        yPos = Random.Range (minY, maxY);
        BasicPredatorScript script = Instantiate (character, new Vector2 (xPos, yPos), Quaternion.Euler (0, 0, 0)).GetComponent<BasicPredatorScript> ();
        script.scale = Random.Range (0.3f, 2f);
    }
}