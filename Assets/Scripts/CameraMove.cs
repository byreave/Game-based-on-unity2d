using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MonoBehaviour {

    private Vector3 ScreenPoint;
    private float posY;
    private List<GameObject> l;
	// Use this for initialization
	void Start () {
        ScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        l = GetComponent<game>().zombieList;
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<game>().canAttack)
        {
            foreach(GameObject g in l)
            {
                if(g != null)
                {
                    transform.position = new Vector3(transform.position.x, g.transform.position.y, transform.position.z);
                    break;
                }
            }
        }
        else
        {
            bool turn = GameObject.FindGameObjectWithTag("Vacuum").GetComponent<VacuumMove>().turnBack;
            if(!turn)
            {
                posY = GameObject.FindGameObjectWithTag("Vacuum").transform.position.y - ScreenPoint.y / 3;
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            }
            else
            {
                posY = GameObject.FindGameObjectWithTag("Vacuum").transform.position.y + ScreenPoint.y / 3;
                transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            }
        }
        
	}
}
