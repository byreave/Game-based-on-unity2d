using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour {
    public float speed = 0.1f;
    public bool towardsRight = true;
    public int lives = 1;
    public bool canMove = true;
    private bool flag = true;
    public float bounceForce = 50.0f;
    private bool isDying = false;

    Vector3 v;

    void Start()
    {
        
        v = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
    }
	// Update is called once per frame

	void Update () {

        if (canMove) //capturing zombie
        {
            transform.Translate(new Vector3(speed, 0.0f, 0.0f));
            if (towardsRight != flag)
            {
                transform.Rotate(new Vector3(0, 180.0f, 0));
                //speed = -speed;
                flag = !flag;
            }
        }
        else //end capturing zombie
        {
            Vector2 vel = GetComponent<Rigidbody2D>().velocity;
            if (Camera.main.GetComponent<game>().canAttack)
            {
               // Debug.Log(GetComponent<Rigidbody2D>().velocity);


                if (transform.position.x > v.x - GetComponent<Renderer>().bounds.size.x / 2)
                {
                    
                    if (vel.x > 10.0f)
                        vel.x = 10.0f;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-vel.x, vel.y);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-bounceForce, 0));
                    //Debug.Log(213);
                }
                if (transform.position.x < GetComponent<Renderer>().bounds.size.x / 2 - v.x)
                {
                    if(vel.x < -10.0f)
                    {
                        vel.x = -10.0f;
                    }
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-vel.x, vel.y);
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(bounceForce, 0));
                    
                }
                //GetComponent<Rigidbody2D>().velocity.Set(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
                if(transform.position.y < 0.0f)
                {
                    Camera.main.GetComponent<game>().zombieList.Remove(gameObject);
                    Destroy(gameObject);
                }
            }
        }
        

        if (lives <= 0 && !isDying)
        {
            //Debug.Log("Destroy");
            GetComponent<Animator>().SetBool("isAlive", false) ;
            
            Camera.main.GetComponent<game>().zombieList.Remove(gameObject);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
            GetComponent<Rigidbody2D>().Sleep();
            isDying = true;
            //Invoke("DestroyZombie", 0.3f);
        }

        if(isDying)
        {
            Invoke("DestroyZombie", 0.3f);
        }
        
	}
    void OnMouseDown()
    {
        if(Camera.main.GetComponent<game>().canAttack)
        {
            GetComponent<AudioSource>().Play();
            //Camera.main.GetComponent<CameraVibrate>().isShake = true;
            lives--;
        }
        //Debug.Log(123);
    }

    void DestroyZombie()
    {
        Destroy(gameObject);
    }
}
