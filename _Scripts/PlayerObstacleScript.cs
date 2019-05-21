using UnityEngine;
using System.Collections;

public class PlayerObstacleScript : MonoBehaviour
{


	int obsHitCounter;
	SoundController sc;
	// Use this for initialization
	void Start ()
	{
		obsHitCounter = PlayerPrefs.GetInt ("TotalObsHit");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter2D (Collider2D incoming)
	{
		//Debug.Log ("tag : " + incoming.tag);

		if (incoming.tag == "Obstacle") {

			PlayerPrefs.SetInt ("TotalObsHit", obsHitCounter + 1);

			if (obsHitCounter == 50) {
				PlayerPrefs.SetInt ("1", 1);
			}
			if (obsHitCounter == 200) {
				PlayerPrefs.SetInt ("2", 1);
			}
			//	incoming.gameObject.SetActive (false);
			Application.LoadLevel ("Gameover");
			sc.Play_die_Sound ();

			//Debug.Log ("hit enemy .OOOOOooooOOO. damage");
			
		}
	}
}
