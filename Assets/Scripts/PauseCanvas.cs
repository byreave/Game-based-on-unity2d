using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseCanvas : MonoBehaviour {
    GameObject[] pauseArr;
    public Sprite soundOn;
    public Sprite soundOff;
    private bool isMute = false;
    void Start()
    {
        
        pauseArr = GameObject.FindGameObjectsWithTag("PauseCanvas"); //Only Buttons...
    }
	public void ClickToBack()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ClickToResume()
    {
        //Game
        GameObject.FindGameObjectWithTag("Vacuum").GetComponent<VacuumMove>().enabled = true;
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject z in zombies)
        {
            z.GetComponent<ZombieMove>().enabled = true;
        }
        Time.timeScale = 1;

        //UI
        GameObject.Find("PauseImage").GetComponent<Image>().enabled = false;
        GameObject.Find("PauseButton").GetComponent<Image>().enabled = true;
        GameObject.Find("PauseButton").GetComponent<Button>().enabled = true;
        foreach (GameObject g in pauseArr)
        {
            g.GetComponent<Image>().enabled = false;
            g.GetComponent<Button>().enabled = false;
        }
    }

    public void ClickToMute()
    {
        if(!isMute)
        {
            AudioListener.pause = true;
            //Camera.main.GetComponent<AudioListener>().enabled = false;
            GameObject.Find("SoundButton").GetComponent<Image>().sprite = soundOff;
            isMute = true;
        }
        else
        {
            AudioListener.pause = false;
            //Camera.main.GetComponent<AudioListener>().enabled = true;
            GameObject.Find("SoundButton").GetComponent<Image>().sprite = soundOn;
            isMute = false;
        }
    }
}
