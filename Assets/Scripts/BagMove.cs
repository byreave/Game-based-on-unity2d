using UnityEngine;
using System.Collections;

public class BagMove : MonoBehaviour {

	// Use this for initialization
    public float speed = 0.1f;
    float posX;
    //float poxY;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        posX = GameObject.Find("tube").transform.position.x;
        transform.position = new Vector3(posX, transform.position.y + speed);

        if(transform.position.y > 3.0f)
        {
            Destroy(gameObject);
        }
	}
}
