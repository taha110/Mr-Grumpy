using UnityEngine;
using System.Collections;

public class SpalshScreen : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

		Invoke ("loadMenuLevel", 3.0f);
		iTween.FadeTo (logo, 1.0f, 1.0f);

		iTween.FadeTo (logo, iTween.Hash ("alpha", 0, "time", 1f, "delay", 2.0f)); 
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	// Update is called once per frame

	void loadMenuLevel ()
	{
		Application.LoadLevel ("Intro");
	}
	 
	public GameObject logo;
	void Update ()
	{

	    
	   

		if (Input.GetKey (KeyCode.Mouse0)) {
			loadMenuLevel ();
		}

		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
