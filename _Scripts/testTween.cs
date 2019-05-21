using UnityEngine;
using System.Collections;

public class testTween : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		iTween.ValueTo (gameObject, iTween.Hash ("from",0,"to",mainCoinsCount,"time",2.0f,"onupdate","updateCounFunction" ));
	}
	
	// Update is called once per frame

	void updateCounFunction(int value)
	{
		CoinsToDisplay = value;
	}
 
	int CoinsToDisplay = 0,mainCoinsCount=100 ;
    void OnGUI()
	{
		GUI.Label( new Rect(0,100,100,30 ) ,"Coins Count " + CoinsToDisplay   );
	}
}
