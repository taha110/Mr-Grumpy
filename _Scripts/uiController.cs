using UnityEngine;
using System.Collections;

public class uiController : MonoBehaviour
{

	// Use this for initialization
	public Camera uiCam;
	public string hitObjName;
	public GameObject playGame, more, review, levels, ui, exit, creditsDetails, share, googlePlus ;
	public Renderer playRender, moreRender, reviewRender, exitRender, shareRender, googlePlusRender;
	public Texture[] playTexture, moreTexture, reviewTexture, exitTexture;

	public Texture2D shareTexture;


	void Start ()
	{
		Time.timeScale = 1;

		//ios store won't accepect exit buttons 
		#if UNITY_IPHONE
		Destroy(exit);
		#endif
	}

	void Update ()
	{
	
	

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray rayObj = uiCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitObject;
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;
			}
			switch (hitObjName) {
			case "Play":
				SoundController.Static.PlayClickSound ();
				playRender.material.mainTexture = playTexture [1];
				//iTween.MoveTo(levels,new Vector3(0,0,0),2f);
				//iTween.MoveTo(ui,new Vector3(-29,0,0),2f);
				break;
			case "More":
				SoundController.Static.PlayClickSound ();
				moreRender.material.mainTexture = moreTexture [1];
				//Application.OpenURL("");
				break;
			case "Review":
				SoundController.Static.PlayClickSound ();
				reviewRender.material.mainTexture = reviewTexture [1];
				//Application.OpenURL("");
				break;
			case "Exit":
				SoundController.Static.PlayClickSound ();
				exitRender.material.mainTexture = exitTexture [1];
				//Application.Quit();
				break;
			case "Credits":
				SoundController.Static.PlayClickSound ();
				break;

			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			Ray rayObj = uiCam.ScreenPointToRay (Input.mousePosition);
			RaycastHit hitObject;
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;
			}
			originalTextures ();
			switch (hitObjName) {
			case "Play":
				playRender.material.mainTexture = playTexture [0];
				iTween.MoveTo (levels, new Vector3 (0, 0, 0), 2f);
				iTween.MoveTo (ui, new Vector3 (-29, 0, 0), 2f);
				break;
			case "More":
				moreRender.material.mainTexture = moreTexture [0];
				Application.OpenURL ("");
				break;
			case "Review":

				break;
			case "Exit":
				exitRender.material.mainTexture = exitTexture [0];
				Application.Quit ();
				break;
			case "Credits":
				iTween.MoveTo (creditsDetails, new Vector3 (0, 1.2f, 0), 2f);
				iTween.MoveTo (ui, new Vector3 (29, 0, 0), 2f);
				
	
				break;		
			}
		}
	}
	public void originalTextures ()
	{
		#if !UNITY_IPHONE
		exitRender.material.mainTexture = exitTexture [0];
		#endif

		reviewRender.material.mainTexture = reviewTexture [0];
		moreRender.material.mainTexture = moreTexture [0];
		playRender.material.mainTexture = playTexture [0];
	}
}
