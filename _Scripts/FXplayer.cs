using UnityEngine;
using System.Collections;

public class FXplayer : MonoBehaviour
{
	GameObject PotionObj;


	public Vector3 myPosition;
	public GameObject myPrefab;
	
	// Use this for initialization
	void Start ()
	{
		Instantiate (myPrefab);
		CFX_SpawnSystem.GetNextObject (myPrefab);
		PotionObj = this.gameObject;

	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject instance = CFX_SpawnSystem.GetNextObject (myPrefab);
		instance.transform.position = PotionObj.transform.position;


	}
}
