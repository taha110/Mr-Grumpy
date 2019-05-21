using UnityEngine;
using System.Collections;

public class ClosePopup : MonoBehaviour
{
	public GameObject lvlChng;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {

			Time.timeScale = 1;
			lvlChng.SetActive (true);
			IngameUI._pause = false;
		}
	}
}
