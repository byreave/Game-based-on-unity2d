using UnityEngine;
using System.Collections;

public class HelicptorFollow : MonoBehaviour {

	// Use this for initialization
    Transform t;
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        t = GameObject.FindGameObjectWithTag("Vacuum").transform;
        transform.position = new Vector2(t.position.x-0.5f, transform.position.y);
	}
}
