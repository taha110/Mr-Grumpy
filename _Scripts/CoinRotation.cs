using UnityEngine;
using System.Collections;

public class CoinRotation : MonoBehaviour {

	// Use this for initialization\\

	public bool enable=false;
	public static int totalCoinCount ;
	void Start () {


		totalCoinCount++;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enable == true) 
		{
			transform.Rotate (new Vector3 (0, 0, Time.deltaTime * 100));
		}

	}
	void OnBecameVisible() 
	{
		enable = true;
	}
}
