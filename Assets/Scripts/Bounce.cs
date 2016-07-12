using UnityEngine;
using System.Collections;

public class Bounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie")
        {
            //Debug.Log(other.gameObject.GetComponent<Rigidbody2D>().velocity);
            if (other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
            else
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 0));
            }

        }
    }
}
