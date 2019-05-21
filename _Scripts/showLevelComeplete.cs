using UnityEngine;
using System.Collections;

public class showLevelComeplete : MonoBehaviour
{

	public GameObject lvlChng;
	bool isShowing;

	// Use this for initialization
	void Start ()
	{
		//this.enabled = false;
		//this.gameObject.SetActive (false);
		//lvlChng.SetActive (false);
		isShowing = false;

	}
	
	// Update is called once per frame
	void Update ()
	{

		if (PlayerController.scoreCounter > 1 && PlayerController.scoreCounter % 10 == 0) {

			if (Time.time >= 1) {
				Debug.Log ("time's up");
				lvlChng.SetActive (true);
				isShowing = true;
			}

			if (isShowing == true) {
				Time.timeScale = 0;
				IngameUI._pause = true;
			} else {
				Time.timeScale = 1;
				IngameUI._pause = false;
			}

		}

	}
}
