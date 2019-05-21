using UnityEngine;
using System.Collections;

public class Levels : MonoBehaviour {


	public Camera LevelsCam;
	public string selectedTxt;
	public Renderer backRender;
	public Texture[] backTexture;
	public GameObject levelloadinParent;
	public uiController UIChild;
	public TextMesh loadingLevelName;
	// Use this for initialization
	void Start () {
	
	}
	RaycastHit hitObject;
	Ray rayObjLevels;
	// Update is called once per frame
	void Update () {



		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			selectedTxt="";
			rayObjLevels = LevelsCam.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (rayObjLevels, out hitObject)) 
			{
				selectedTxt=hitObject.collider.name;
			}


		
			if(selectedTxt.Contains("Level"))
			{
				SoundController.Static.PlayClickSound();
				iTween.MoveTo(levelloadinParent,iTween.Hash("position", new Vector3(0,1.5f,0)));
				loadingLevelName.text=hitObject.collider.name;
				iTween.MoveTo (UIChild.levels,iTween.Hash("position" ,new Vector3(29,0,0)));
				StartCoroutine(MyLoadLevel());
			//Application.LoadLevel(selectedTxt);
			}
			switch(selectedTxt)
			{
//			case "Level 1":
//				Application.LoadLevel("Level 1");
//				break;
//			case "Level 2":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 3":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 4":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 5":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 6":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 7":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 8":
//				Application.LoadLevel("Level1");
//				break;
//			case "Level 9":
//				Application.LoadLevel("Level1");
//				break;
			case "Back":
				backRender.material.mainTexture=backTexture[1];
				//Application.LoadLevel("Home");
				break;


			}

				}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			selectedTxt="";
			rayObjLevels = LevelsCam.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (rayObjLevels, out hitObject)) 
			{
				selectedTxt=hitObject.collider.name;
			}

			//if(selectedTxt.Contains("Level")) Application.LoadLevel(selectedTxt);
			switch(selectedTxt)
			{
			case "Back":
				SoundController.Static.PlayClickSound();
				backRender.material.mainTexture=backTexture[0];
				iTween.MoveTo(UIChild.ui,new Vector3(0,0,0),2f);
				iTween.MoveTo(UIChild.levels,new Vector3(29,0,0),2f);
//				if(UIChild.ui.transform.position==new Vector3(29,0,0) && UIChild.creditsDetails.transform.position==new Vector3(0,0,0))
//				{
//					iTween.MoveTo(UIChild.ui,new Vector3(0,0,0),2f);
//					iTween.MoveTo(UIChild.creditsDetails,new Vector3(-29,0,0),1f);
//				}

				break;
			case "Back1":
				SoundController.Static.PlayClickSound();
				iTween.MoveTo(UIChild.ui,new Vector3(0,0,0),2f);
				iTween.MoveTo(UIChild.creditsDetails,new Vector3(-29,0,0),1f);
				break;
				
				
			}
			
		}
		if(Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	
	}
	IEnumerator MyLoadLevel()
	{
		yield return new WaitForSeconds(3f);
		Application.LoadLevel(loadingLevelName.text);
		}
}
