using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BeginScript : MonoBehaviour {

	public void ClickToBegin()
    {
        GameObject.FindWithTag("Vacuum").GetComponent<VacuumMove>().BeginMove = true;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
