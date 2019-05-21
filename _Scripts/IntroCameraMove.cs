using UnityEngine;
using System.Collections;

public class IntroCameraMove : MonoBehaviour
{
	bool pauseIntro;
	public Vector3 offset ;
	Transform targetTransform ;
	void Start ()
	{
		pauseIntro = false;
		targetTransform = GameObject.Find ("Main Camera").GetComponent<Transform> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			pauseIntro = true;
		} 
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			pauseIntro = false;
		} 


		if (targetTransform.position.x < 85) {
			if (!pauseIntro) {
				transform.position = new Vector3 (targetTransform.position.x + offset.x, transform.position.y, transform.position.z);
			}
		}

	}

}

