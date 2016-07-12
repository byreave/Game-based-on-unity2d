using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class game : MonoBehaviour {

    public List<GameObject> zombieList;
    public Text txt;
    public bool startLaunch = false;
    public float minForce = 400.0f;
    public float forceRatio = 400.0f;
    public bool canAttack = false;
    public float sizeMultiplier = 3.0f;
	// Use this for initialization
	void Start () {
        txt.fontStyle = FontStyle.Bold;
        txt.font = Font.CreateDynamicFontFromOSFont("Arial", 48);
        Time.timeScale = 1;
        AudioListener.pause = false;
        //if (PlayerPrefs.GetInt("Money") == null)
        //{
        //    PlayerPrefs.SetInt("Money", 0);
        //}
        //GameObject.Find("Money").
        //Time.timeScale = 0;
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
        //Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        //Debug.Log(v);
	}
	
	// Update is called once per frame
	void Update () {
        //Return on android
        if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown(KeyCode.Escape)))
        {
            SceneManager.LoadScene("StartScene");
        }
        
        txt.text = PlayerPrefs.GetInt("Money").ToString();
	    if(startLaunch)
        {
            //Debug.Log(12333);
            canAttack = true;
            foreach(GameObject z in zombieList)
            {
                //Debug.Log(123334);
                //Debug.Log(zombieList.Count);
                z.transform.position = GameObject.FindGameObjectWithTag("Vacuum").transform.position;
                z.GetComponent<Collider2D>().enabled = true;
                Vector2 v = z.GetComponent<BoxCollider2D>().size;
                z.GetComponent<BoxCollider2D>().size = v * sizeMultiplier;
                //z.GetComponent<Collider2D>().bounds.size;
                z.GetComponent<Renderer>().enabled = true;
                z.GetComponent<Rigidbody2D>().gravityScale = 0.3f;

                z.GetComponent<Rigidbody2D>().AddForce(new Vector2((Random.value-0.5f) * (forceRatio+minForce), Random.value * forceRatio + minForce));
            }
            //Debug.Log(zombieList.Count);

            startLaunch = false;
        }

        if(canAttack && zombieList.Count == 0)
        {
            //Debug.Log(222);
            //Time.timeScale = 0;
            Invoke("RestartGame", 2.0f);
        }
	}

    void RestartGame()
    {
        SceneManager.LoadScene("TestScene");
    }
}
