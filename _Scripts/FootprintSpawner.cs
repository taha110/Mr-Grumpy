using UnityEngine;
using System.Collections;

public class FootprintSpawner : MonoBehaviour
{

	float counter = 0;
	float checker = 0;
	public GameObject FootleftObj;
	public GameObject FootRightObj;
	bool FootRightTurn;
	CharacterController cont;

	// Use this for initialization
	void Start ()
	{
		FootRightTurn = true;
		counter = 0.20f;
		checker = 0f;
		cont = GetComponent<CharacterController> ();


	}

	void FixedUpdate ()
	{
		if (PlayerController.groundPerHai) {
			if (checker >= counter) {
			
				if (FootRightTurn) {
					GameObject cubeSpawn = (GameObject)Instantiate (FootRightObj, new Vector3 (-6.24f, -3.2f, -0.4f), transform.rotation);
					checker = 0;
					FootRightTurn = false;
				} else {
					GameObject cubeSpawn = (GameObject)Instantiate (FootleftObj, new Vector3 (-6.24f, -2.9f, -0.4f), transform.rotation);
					checker = 0;				
					FootRightTurn = true;
				
				}
				//(!FootRightTurn)
			}
			checker += Time.deltaTime;
		}
	}
	// Update is called once per frame
	void Update ()
	{

	
	}
}
