using UnityEngine;
using System.Collections;

public class AirWall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie")
        {
            other.GetComponent<ZombieMove>().towardsRight = !other.GetComponent<ZombieMove>().towardsRight;
        }
    }
}
