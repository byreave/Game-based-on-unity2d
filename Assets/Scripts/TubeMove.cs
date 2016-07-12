using UnityEngine;
using System.Collections;

public class TubeMove : MonoBehaviour {

	// Use this for initialization
    //Transform t;
    GameObject g;
    float distanceY;
	void Start () {
        //t = transform;
        g = GameObject.FindGameObjectWithTag("Vacuum");
        distanceY = transform.position.y - g.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(g.transform.position.x, g.transform.position.y + distanceY);
	}
}
