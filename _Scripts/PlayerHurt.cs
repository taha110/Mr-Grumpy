using UnityEngine;
using System.Collections;

public class PlayerHurt : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		//guiTexture.pixelInset = new Rect (0, 0, Screen.width, Screen.height);

	//GUITexture.pixelInset=
	}
	
	// Update is called once per frame
	public void Update () {
						GetComponent<GUITexture>().pixelInset = new Rect (0, 0, Screen.width, Screen.height);
						iTween.FadeTo (gameObject, 0, 1.0f);
	
	}
}
