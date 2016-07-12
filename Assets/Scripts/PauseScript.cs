using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour {

    GameObject[] pauseArr;
    void Start()
    {
        pauseArr = GameObject.FindGameObjectsWithTag("PauseCanvas"); //Only Buttons...
    }
	public void ClickToPause()
    {
        //Game
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Vacuum").GetComponent<VacuumMove>().enabled = false;
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach(GameObject z in zombies)
        {
            z.GetComponent<ZombieMove>().enabled = false;
        }

        //UI
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().enabled = false;
        GameObject.Find("PauseImage").GetComponent<Image>().enabled = true;
        foreach(GameObject g in pauseArr)
        {
            g.GetComponent<Image>().enabled = true;
            g.GetComponent<Button>().enabled = true;
        }
    }
}
