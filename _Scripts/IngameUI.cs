using UnityEngine;
using System.Collections;
using System;
public class IngameUI : MonoBehaviour
{
	
	// Use this for initialization
	public Camera mainCam;
	public string hitObjName;
	public int numberofCoins, life = 3, CoinsToDisplay, scoreToDisplay;
	public static int scoreCount;
	public TextMesh displyCount, lifeText, gameOver, finalCoins, scoreCountTxt, finalScoreTxt;
	public Transform target;
	public GameObject levelCompleted, star1, star2, star3, coinCount, lifeCount, pauseButton, themeChanger, GverTryAgain, home, resume, pauseContainer, scoreParent, LevelIndicatorParent, scoreBoardMenu;
	public Renderer nextRender, reloadRender, homeRender;
	public Texture[] nextTexture, reloadTexture, homeTexture;
	public bool i = true;
	public  float percentage;
	public PlayerController playerControllerChild;
	public bool isGameEnded = false;
	public bool isLevelEnd = false;

	public static bool _pause;


	void OnEnable ()
	{
		CollisionAndTrigger.displayAd += displayerAD;
	 
	}

	void displayerAD (System.Object obj, EventArgs args)
	{
		Debug.Log ("Ad called");
	}
	void Start ()
	{
		_pause = false;

		scoreCount = 0;
		lifeText.text = life.ToString ();
		isGameEnded = false;


		//-1.0,6.5f

		
		if (Camera.main.aspect >= 1.5) { //3:2
			//nochange
		} else {
			mainCam.orthographicSize = 6.5f;
			mainCam.transform.Translate (0, -1, 0);
		}
		
	}
	public void  finalCoinsCaliculations ()
	{
		Time.timeScale = 1;
		iTween.ValueTo (gameObject, iTween.Hash ("delay", 1f, "from", 0, "to", numberofCoins, "time", 2.0f, "onupdate", "onUpdateCount", "onstart", "playCountingSound", "onstarttarget", gameObject));
		iTween.ValueTo (gameObject, iTween.Hash ("delay", 3f, "from", 0, "to", scoreCount, "time", 2.0f, "onupdate", "onUpdateCountforScore", "onstart", "playCountingSound", "onstarttarget", gameObject));
		
	}
	void playCountingSound ()
	{
		SoundController.Static.playcoinCounting ();
	}
	void onUpdateCount (int value)
	{
		CoinsToDisplay = value;
		
		
	}
	void onUpdateCountforScore (int value1)
	{
		scoreToDisplay = value1;
		
		
	}
	Ray rayObj;
	RaycastHit hitObject;
	// Update is called once per frame
	void Update ()
	{
		
		finalCoins.text = "Coins X " + CoinsToDisplay;
		finalScoreTxt.text = "Score X  " + scoreToDisplay;
		scoreCountTxt.text = scoreCount.ToString ();
		
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			rayObj = mainCam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;
				switch (hitObjName) {
//				case "resume":
//					pauseContainer.SetActive(false);
//					pauseButton.SetActive(true);
//					Time.timeScale = 1;
//					break;
//				case "pause":
//					if(Time.timeScale == 1)
//					{
//						pauseContainer.SetActive(true);
//						pauseButton.SetActive(false);
//						pauserender.material.mainTexture = pauseTexture [1];
//						Time.timeScale = 0;
//					}
//					else
//					{
//						pauseContainer.SetActive(false);
//						pauserender.material.mainTexture = pauseTexture [0];
//						Time.timeScale = 1;
//					}
//					break;
				case "Next":
					SoundController.Static.PlayClickSound ();
					nextRender.material.mainTexture = nextTexture [1];
					//Application.LoadLevel("Level 2");
					break;
				case "PlayAgain":
					SoundController.Static.PlayClickSound ();
					reloadRender.material.mainTexture = reloadTexture [1];
					//Application.LoadLevel("Level 1");
					break;
				case "main menu":
					SoundController.Static.PlayClickSound ();
					homeRender.material.mainTexture = homeTexture [1];
					//Application.LoadLevel("Home");
					break;
				case "home":
					//Application.LoadLevel("Home");
					break;
					
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			originalTextures ();
			rayObj = mainCam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayObj, out hitObject)) {
				hitObjName = hitObject.collider.name;

				switch (hitObjName) {
				case "resume":
					pauseContainer.SetActive (false);
					ActiveIngameUI ();
					Time.timeScale = 1;
					_pause = false;
					break;
				case "pause":
					if (Time.timeScale == 1) {
						pauseContainer.SetActive (true);
						DeactiveIngameUI ();
						Time.timeScale = 0;
						_pause = true;
						//GameObject.FindGameObjectWithTag("ADS").SendMessage("showFullAD",SendMessageOptions.DontRequireReceiver);
					} else {
						pauseContainer.SetActive (false);
						Time.timeScale = 1;
						_pause = false;
					}
					break;
				case "Next":
					nextRender.material.mainTexture = nextTexture [0];
					Application.LoadLevel (Application.loadedLevel + 1);
					break;
				case "PlayAgain":
					reloadRender.material.mainTexture = reloadTexture [0];
					Time.timeScale = 1;
					_pause = false;

					Application.LoadLevel (Application.loadedLevelName);
					break;
				case "main menu":
					homeRender.material.mainTexture = homeTexture [0];
					_pause = false;

					Application.LoadLevel ("HomeFinal");
					break;
				case "home":
					Application.LoadLevel ("HomeFinal");
					_pause = false;

					break;
				case "go_desert":
					Application.LoadLevel ("Level Desert");
					_pause = false;
				
					break;
				
				}

			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (isGameEnded == false) {
				if (Time.timeScale == 1) {
					pauseContainer.SetActive (true);
					DeactiveIngameUI ();
					Time.timeScale = 0;
				} else {
					pauseContainer.SetActive (false);
					ActiveIngameUI ();
					Time.timeScale = 1;
				}

								

			}
			if (isLevelEnd == true) {
				Application.LoadLevel ("Home");
			}

		}
	}
	public void OnLevelEndEscape ()
	{
		isLevelEnd = true;

	}

	public void DeactiveIngameUI ()
	{
		coinCount.SetActive (false);
		lifeCount.SetActive (false);
		pauseButton.SetActive (false);
		themeChanger.SetActive (false);

		scoreParent.SetActive (false);
		LevelIndicatorParent.SetActive (false);

	}
	public void ActiveIngameUI ()
	{
		coinCount.SetActive (true);
		lifeCount.SetActive (true);
		pauseButton.SetActive (true);
		themeChanger.SetActive (true);
		scoreParent.SetActive (true);
		LevelIndicatorParent.SetActive (true);


	}
	public void OnLevelEnd ()
	{

		isGameEnded = true;
		scoreBoardMenu.transform.Translate (0, -10, 0);
		iTween.MoveTo (scoreBoardMenu, iTween.Hash ("islocal", true, "position", new Vector3 (0, 0, 0), "time", 1f, "delay", 6f, "easetype", iTween.EaseType.easeInOutBack, "onstart", "playCountingSound", "onstarttarget", gameObject, "oncomplete", "OnLevelEndEscape", "oncompletetarget", gameObject)); 
		iTween.MoveTo (levelCompleted, iTween.Hash ("islocal", true, "position", new Vector3 (-0.5156403f, -0.05f, 0), "time", 1f));
		finalCoinsCaliculations ();
		DeactiveIngameUI ();
		PercentageCaliculation ();
		StarsDisplay ();
//		GameObject.FindGameObjectWithTag("ADS").SendMessage("showFullAD",SendMessageOptions.DontRequireReceiver);
	}
	public void StarsDisplay ()
	{
		if (numberofCoins < 20) {
			PlayerPrefs.SetInt (Application.loadedLevelName, 0);
		} else if (numberofCoins > 20 && numberofCoins < 30) {

			PlayerPrefs.SetInt (Application.loadedLevelName, 1);
			star1.SetActive (true);
			Vector3 OriginalScale = star1.transform.localScale;
			star1.transform.localScale = new Vector3 (40, 40, 1);
			iTween.ScaleTo (star1, iTween.Hash ("scale", OriginalScale, "time", 0.4f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5f, "onstart", "EnableStar1Render", "onstarttarget", gameObject));
			//print ("50");
		} else if (numberofCoins < 45 && numberofCoins > 30) {

			PlayerPrefs.SetInt (Application.loadedLevelName, 2);

			star1.SetActive (true);
			star2.SetActive (true);
			Vector3 OriginalScale = star1.transform.localScale;
			star1.transform.localScale = new Vector3 (40, 40, 1);
			 
			iTween.ScaleTo (star1, iTween.Hash ("scale", OriginalScale, "time", 0.4f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5f, "onstart", "EnableStar1Render", "onstarttarget", gameObject));
			OriginalScale = star2.transform.localScale;
			star2.transform.localScale = new Vector3 (40, 40, 1);
			iTween.ScaleTo (star2, iTween.Hash ("scale", OriginalScale, "time", 0.4f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5.5f, "onstart", "EnableStar2Render", "onstarttarget", gameObject));
			//print ("51 and  94");
		} else if (numberofCoins > 44) {

			PlayerPrefs.SetInt (Application.loadedLevelName, 3);
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);

			Vector3 OriginalScale = star1.transform.localScale;
			star1.transform.localScale = new Vector3 (40, 40, 1);
			iTween.ScaleTo (star1, iTween.Hash ("scale", OriginalScale, "time", 0.3f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5f, "onstart", "EnableStar1Render", "onstarttarget", gameObject));

			OriginalScale = star2.transform.localScale;
			star2.transform.localScale = new Vector3 (40, 40, 1);
			iTween.ScaleTo (star2, iTween.Hash ("scale", OriginalScale, "time", 0.3f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5.5f, "onstart", "EnableStar2Render", "onstarttarget", gameObject));

			OriginalScale = star3.transform.localScale;
			star3.transform.localScale = new Vector3 (40, 40, 1);
			iTween.ScaleTo (star3, iTween.Hash ("scale", OriginalScale, "time", 0.3f, "easetype", iTween.EaseType.easeInOutBounce, "delay", 5.99f, "onstart", "EnableStar3Render", "onstarttarget", gameObject));
			//print ("95");
		}
	}
	public void EnableStar1Render ()
	{
		SoundController.Static.playStarsSound ();
		star1.GetComponent<Renderer> ().enabled = true;
	}
	public void EnableStar2Render ()
	{
		SoundController.Static.playStarsSound ();
		star1.GetComponent<Renderer> ().enabled = true;
		star2.GetComponent<Renderer> ().enabled = true;
	}
	public void EnableStar3Render ()
	{
		SoundController.Static.playStarsSound ();
		star1.GetComponent<Renderer> ().enabled = true;
		star3.GetComponent<Renderer> ().enabled = true;
	}
	public void PercentageCaliculation ()
	{
		float temp = 100 * numberofCoins;
		percentage = temp / CoinRotation.totalCoinCount;

	}
	public void OnGameOver ()
	{
		if (life < 0) {
			DeactiveIngameUI ();
			
			GverTryAgain.SetActive (true);
			GameObject.FindGameObjectWithTag ("PlayerRender").GetComponent<Renderer> ().enabled = false;
			Time.timeScale = 0;
			OnLifeCountZero ();
			//gameObject.GetComponent<playerControl>().enabled=false;
			//	GameObject.FindGameObjectWithTag("ADS").SendMessage("showFullAD",SendMessageOptions.DontRequireReceiver);
		}

	}
	public void originalTextures ()
	{
		reloadRender.material.mainTexture = reloadTexture [0];
		homeRender.material.mainTexture = homeTexture [0];
		nextRender.material.mainTexture = nextTexture [0];
	}
	public void OnLifeCountZero ()
	{
		//playerControllerChild.movement.runSpeed = 0;
		//playerControllerChild.movement.walkSpeed = 0;
		//gameObject.GetComponent<PlayerController>().enabled=false;
		//playerScript.SetActive = false;
	}
	
}
