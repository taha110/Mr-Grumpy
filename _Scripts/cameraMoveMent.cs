using UnityEngine;
using System.Collections;

public class cameraMoveMent : MonoBehaviour {

	// Use this for initialization

	public Vector3 offset ;
	Transform targetTransform ;
	void Start () {

		targetTransform = GameObject.Find ("player").GetComponent<Transform> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3( targetTransform.position.x + offset.x,transform.position.y,transform.position.z  );

	}
}
