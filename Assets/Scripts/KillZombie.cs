using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillZombie : MonoBehaviour {
    private List<GameObject> l;

    public float attackRadius = 5.0f;
    public bool canAttack = false;
	// Use this for initialization
	void Start () {
        l = GetComponent<game>().zombieList;
	}
	
	// Update is called once per frame
	void Update () {
	    if(canAttack &&Input.GetButton("Fire1"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.Set(pos.x, pos.y, 0.0f);
            Debug.Log(pos);
            foreach(GameObject z in l)
            {
                //Debug.Log(z.transform.position);
                Vector2 v = z.transform.position - pos;
                Debug.Log(v.magnitude);
                if(v.magnitude <= attackRadius)
                {
                    Debug.Log(123213);
                    z.gameObject.GetComponent<ZombieMove>().lives--;
                }
            }
        }
	}
}
