using UnityEngine;
using System.Collections;
public class VacuumMove : MonoBehaviour {

    public float xSpeed = 0.3f;
    public float ySpeed = -0.3f;
    public bool BeginMove = false;
    private float maxLeft = 0.0f;
    private float maxRight = 0.0f;
    private float tempX;
    private Quaternion targetRotation;

    bool flag = false;
    public bool turnBack = false;
	// Use this for initialization
	void Start () {
        //Debug.Log(GetComponent<Renderer>().bounds.size.x);
        maxLeft = 0.0f;
        maxRight = Screen.width;
        //Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        //maxLeft = GetComponent<Renderer>().bounds.size.x / 2 - v.x;
        //maxRight = v.x - GetComponent<Renderer>().bounds.size.x / 2;
        GameObject AWL = GameObject.Find("AirWallLeft");
        GameObject AWR = GameObject.Find("AirWallRight");
        maxLeft = AWL.transform.position.x + AWL.GetComponent<Collider2D>().bounds.size.x / 2; 
        maxRight = AWR.transform.position.x - AWR.GetComponent<Collider2D>().bounds.size.x / 2;
        tempX = xSpeed;
        targetRotation = Quaternion.Euler(180f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y < -61.0f)
        {
            turnBack = true;
        }
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        if(transform.position.y >= 0.0f && flag == false && turnBack)
        {
            BeginMove = false;
            GetComponentInChildren<EncounterZombie>().beforeLaunch = false;
            Camera.main.GetComponent<game>().startLaunch = true;
            flag = true;
        }
        if (BeginMove)
        {
            transform.Translate(Input.acceleration.x * xSpeed, ySpeed, 0.0f);
            if (transform.position.x <= maxLeft && Input.acceleration.x <= 0)
            {
                xSpeed = 0;
                transform.position = new Vector2(maxLeft, transform.position.y);
            }
            if (transform.position.x >= maxRight && Input.acceleration.x >= 0)
            {
                xSpeed = 0;
                transform.position = new Vector2(maxRight, transform.position.y);
            }
            if (transform.position.x <= maxLeft && Input.acceleration.x >= 0)
                xSpeed = tempX;
            if (transform.position.x >= maxRight && Input.acceleration.x <= 0)
                xSpeed = tempX;

        }

        if(turnBack)
        {
            transform.rotation = targetRotation;
        }
	}
}
