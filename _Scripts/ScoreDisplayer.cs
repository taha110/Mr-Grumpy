using UnityEngine;
using System.Collections;

public class ScoreDisplayer : MonoBehaviour
{
	AchievementNotification an;
	public GameObject sc;

	// Use this for initialization
	void Start ()
	{
		sc = GameObject.Find ("ScoreDisplay");
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<TextMesh> ().text = "Score : " + PlayerController.scoreCounter;
		if (PlayerController.scoreCounter == 1) {
			PlayerPrefs.SetInt ("5", 1);
		}
		if (PlayerController.scoreCounter == 100) {
			PlayerPrefs.SetInt ("6", 1);
		}
		if (PlayerController.scoreCounter == 200) {
			PlayerPrefs.SetInt ("7", 1);
		}
		if (PlayerController.scoreCounter == 300) {
			PlayerPrefs.SetInt ("0", 1);
		}
	}
}
