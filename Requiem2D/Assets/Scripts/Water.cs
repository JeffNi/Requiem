using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour { /*

    float[] xPos;
    float[] yPos;
    float[] velocity;
    float[] accel;
    LineRenderer Water;
    GameObject[] meshObject;
    Mesh[] mesh;
    GameObject[] collider;
    //Constants
    const float SPRING = 0.02f;
    const float DAMPING = 0.04f;
    const float SPREAD = 0.05f;
    const float zPos = -1f;
    //Variables
    float baseHeight;
    float left;
    float bottom;
    //Public variables
    public GameObject splash:
        public Material mat:
        public GameObject waterMesh:

        // Start is called before the first frame update
        void Start () {

        }

    // Update is called once per frame
    void Update () {

    }

    public void CreateWater (float Left, float Width, float Top, float Bottom) {
        int edgeCount = Mathf.RoundToInt (width) * 5;
        int nodeCount = edgeCount + 1;

        Water = gameObject.AddComponent<LineRenderer> ();
        Water.material = mat;
        Water.material.renderQueue = 1000;
        Water.SetVertexCount (nodeCount);
        Water.SetWidth (0.1f, 0.1f);

        xPos = new float[nodeCount];
        yPos = new float[nodeCount];
        velocity = new float[nodeCount];
        accel = new float[nodeCount];

        meshObject = new GameObject[edgeCount];
        mesh = new Mesh[edgeCount];
        collider = new GameObject[edgeCount];

        baseHeight = Top;
        left = Left;
        bottom = Bottom;

        for (int i = 0; i < nodecount; i++) {
            yPos[i] = Top;
            xPos[i] = Left + Width * i / edgecount;
            accel[i] = 0;
            velocity[i] = 0;
            Body.SetPosition (i, new Vector3 (xPos[i], yPos[i], zPos));
        }

        for (int i = 0; i < edgeCount; i++) {
            mesh[i] = new Mesh ();
            Vector3[] Vertices = new Vector3[4];
            Vertices[0] = new Vector3 (xPos[i], yPos[i], zPos);
            Vertices[1] = new Vector3 (xPos[i + 1], yPos[i + 1], zPos);
            Vertices[2] = new Vector3 (xPos[i], bottom, zPos);
            Vertices[3] = new Vector3 (xPos[i + 1], bottom, zPos);
            Vector2[] UVs = new Vector2[4];
            UVs[0] = new Vector2 (0, 1);
            UVs[1] = new Vector2 (1, 1);
            UVs[2] = new Vector2 (0, 0);
            UVs[3] = new Vector2 (1, 0);

            int[] tris = new int[6] { 0, 1, 3, 3, 2, 0 };
            meshes[i].vertices = Vertices;
            meshes[i].uv = UVs;
            meshes[i].triangles = tris;
            meshobjects[i] = Instantiate (watermesh, Vector3.zero, Quaternion.identity) as GameObject;
            meshobjects[i].GetComponent<MeshFilter> ().mesh = meshes[i];
            meshobjects[i].transform.parent = transform;
        }
    } */
}