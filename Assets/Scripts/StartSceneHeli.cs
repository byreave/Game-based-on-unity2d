using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartSceneHeli : MonoBehaviour {

	// Use this for initialization
    public Sprite t1;
    public Sprite t2;
    int timer = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer++;
	    if(timer == 15)
        {
            GetComponent<Image>().sprite = t2;
        }
        if(timer == 30)
        {
            GetComponent<Image>().sprite = t1;
            timer = 0;
        }
	}
}
