using UnityEngine;
using System.Collections;

public class ScoreMover : MonoBehaviour {

	// Use this for initialization

	public Texture tex200;
	void Start () {

		if (SoundController.Static != null)
						SoundController.Static.playCoinHit ();

		Hashtable ht = new Hashtable ();
		if (transform.position.y > 2) {
						IngameUI.scoreCount += 200;
			GetComponent<Renderer>().material.mainTexture=tex200;
			ht.Add ("position",transform.position+new Vector3(0,-3,0));
				}
		else {
						IngameUI.scoreCount += 100;
			ht.Add ("position",transform.position+new Vector3(0,3,0));
				}


		transform.Translate (0,0,-2);



		ht.Add ("time",1f);

		switch(Random.Range(0,6))
		 {
		case 0:
			ht.Add ("easetype",iTween.EaseType.easeInBounce);
			break;
		case 1:
			ht.Add ("easetype",iTween.EaseType.easeInOutSine);
			break;
		case 2:
			ht.Add ("easetype",iTween.EaseType.easeInExpo);
			break;
		case 3:
			ht.Add ("easetype",iTween.EaseType.easeInOutExpo);
			break;
		case 4:
			ht.Add ("easetype",iTween.EaseType.easeInOutQuart);
			break;
		case 5:
			ht.Add ("easetype",iTween.EaseType.easeInQuad);
			break;
		}
		 
		iTween.MoveTo(gameObject,ht );
		iTween.FadeTo (gameObject, iTween.Hash ("delay", 0.5f, "time", 0.5f, "alpha", 0));
		Destroy (gameObject, 2);
	}

}
