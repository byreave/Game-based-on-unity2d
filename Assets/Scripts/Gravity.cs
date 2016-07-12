using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	// Use this for initialization
    public Texture2D sprite;
    float x = 0.0f;
    float y = 0.0f;
    float Max_X = 0.0f;
    float Max_Y = 0.0f;

    void Start()
    {
        Max_X = Screen.width - sprite.width;
        Max_Y = Screen.height - sprite.height;
    }
	void OnGUI()
    {
        //整体显示 x y z 重力感应的重力分量
        string i = PlayerPrefs.GetInt("Money").ToString();
        GUI.Label(new Rect(0, 0, 480, 100), "position is " + Input.acceleration);
        GUI.Label(new Rect(0, 300, 480, 100), "Money is " + i);

        if(GUI.Button(new Rect(200, 100, 100, 50), "Add"))
        {
            if (PlayerPrefs.GetInt("Life") != 0)
                PlayerPrefs.SetInt("Life", PlayerPrefs.GetInt("Life") + 1);
            else
                PlayerPrefs.SetInt("Life", 1);
            //GameObject.Find("TestZombie").GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 400));
            //Debug.Log("123");
        }
        //绘制物体
        GUI.DrawTexture(new Rect(x, y, sprite.width, sprite.height), sprite);
    }
	
	// Update is called once per frame
	void Update () {
        x += Input.acceleration.x * 30;
        y += -Input.acceleration.y * 30;

        //避免物体超出屏幕
        if (x < 0)
        {
            x = 0;
        }
        else if (x > Max_X)
        {
            x = Max_X;
        }

        if (y < 0)
        {
            y = 0;
        }
        else if (y > Max_Y)
        {
            y = Max_Y;
        }
	
	}
}
