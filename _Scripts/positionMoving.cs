using UnityEngine;
using System.Collections;

public class positionMoving : MonoBehaviour {

	bool canMove=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.B)) {
			canMove=true;
		}
		if(canMove)
			transform.Translate (0.1f, 0, 0);
		if (Input.GetKey (KeyCode.V)) {
			canMove=false;
		}
	
	}
}
