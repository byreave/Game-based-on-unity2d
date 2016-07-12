using UnityEngine;
using System.Collections;

public class CreateZombie : MonoBehaviour {

    public float interval = 2.06f;
    public int maxFloor = 30;
    public GameObject zombiePrefab1;
    public GameObject zombiePrefab2;
    public GameObject zombiePrefab3;
    public float leftMargin;
    public float rightMargin;
	// Use this for initialization
	void Start () {
        GameObject AWL = GameObject.Find("AirWallLeft");
        GameObject AWR = GameObject.Find("AirWallRight");
        leftMargin = AWL.transform.position.x + AWL.GetComponent<Collider2D>().bounds.size.x / 2 +zombiePrefab1.GetComponent<Renderer>().bounds.size.x / 2;
        rightMargin = AWR.transform.position.x - AWR.GetComponent<Collider2D>().bounds.size.x / 2 - zombiePrefab1.GetComponent<Renderer>().bounds.size.x / 2;

	    for(int i = 0; i < maxFloor; ++ i)
        {
            
            if(i < 10)
            {
                float x_Pos = Random.Range(leftMargin, rightMargin);
                float y_Pos = -2.06f * i;
                GameObject zombie = getRandomZombie();
                Instantiate(zombie, new Vector3(x_Pos, y_Pos), Quaternion.identity);
            }
            else if (i >= 10 && i < 20)
            {
                float x_Pos1 = Random.Range(leftMargin, rightMargin);
                float x_Pos2 = Random.Range(leftMargin, rightMargin);
                float y_Pos = -2.06f * i;
                GameObject zombie1 = getRandomZombie();
                GameObject zombie2 = getRandomZombie();
                Instantiate(zombie1, new Vector3(x_Pos1, y_Pos), Quaternion.identity);
                Instantiate(zombie2, new Vector3(x_Pos2, y_Pos), Quaternion.identity);

            }
            else
            {
                float x_Pos1 = Random.Range(leftMargin, rightMargin);
                float x_Pos2 = Random.Range(leftMargin, rightMargin);
                float x_Pos3 = Random.Range(leftMargin, rightMargin);

                float y_Pos = -2.06f * i;
                GameObject zombie1 = getRandomZombie();
                GameObject zombie2 = getRandomZombie();
                GameObject zombie3 = getRandomZombie();

                Instantiate(zombie1, new Vector3(x_Pos1, y_Pos), Quaternion.identity);
                Instantiate(zombie2, new Vector3(x_Pos2, y_Pos), Quaternion.identity);
                Instantiate(zombie3, new Vector3(x_Pos3, y_Pos), Quaternion.identity);

            }
        }
	}
	
    GameObject getRandomZombie()
    {
        int z = Random.Range(0, 3);
        GameObject zombie;
        switch (z)
        {
            case 0:
                zombie = zombiePrefab1;
                break;
            case 1:
                zombie = zombiePrefab2;
                break;
            case 2:
                zombie = zombiePrefab3;
                break;
            default:
                zombie = zombiePrefab1;
                break;
        }
        return zombie;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
