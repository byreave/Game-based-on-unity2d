using UnityEngine;
using System.Collections;

public class EncounterZombie : MonoBehaviour {

    public bool beforeLaunch = true;
    public GameObject bag;
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Zombie" && beforeLaunch)
        {
            //Debug.Log("123");
            GetComponent<AudioSource>().Play();
            other.enabled = false;
            other.GetComponentInParent<Renderer>().enabled = false;
            other.GetComponentInParent<ZombieMove>().canMove = false;
            GetComponentInParent<VacuumMove>().turnBack = true;
            Camera.main.GetComponent<game>().zombieList.Add(other.gameObject);
            float posY = transform.position.y + GetComponentInParent<Renderer>().bounds.size.y;

            Instantiate(bag, new Vector2(transform.position.x, posY), Quaternion.identity);
        }
    }
}
