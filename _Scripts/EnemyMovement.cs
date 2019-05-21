using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

	public AchievementNotification AN;


	public float Distance;
	
	GameObject EnemyObj;
	GameObject PlayerObj ;
	Transform position;
	public Vector3 EnemyVelocity;

	SoundController sc;
	// Soul Anim
	GameObject PotionObj;
	public Vector3 myPosition;
	public GameObject myPrefab;


	// Use this for initialization
	void Start ()
	{
		//	EnemyObj = GameObject.FindGameObjectWithTag ("Enemy");
		PlayerObj = GameObject.FindGameObjectWithTag ("Player");
		EnemyObj = this.gameObject;


		// Soul Anim
		Instantiate (myPrefab);
		CFX_SpawnSystem.GetNextObject (myPrefab);
		PotionObj = this.gameObject;

	}
	
	// Update is called once per frame
	void Update ()
	{
		Distance = Vector2.Distance (PlayerObj.transform.position, EnemyObj.transform.position);
		//Debug.Log ("Distance : " + Distance);

		if (Distance < 10) {
			EnemyObj.transform.position -= EnemyVelocity;

			//	EnemyObj.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			//	transform.position = EnemyVelocity;

		}

	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
		if (col.tag == "Player") {
			//	incoming.gameObject.SetActive (false);
			//Application.LoadLevel ("Gameover");
			Debug.Log ("hit enemy .. damage");
			
			GameObject instance = CFX_SpawnSystem.GetNextObject (myPrefab);
			instance.transform.position = PotionObj.transform.position;

			PlayerController.scoreCounter = PlayerController.scoreCounter + 1;
			AN.AddAchievementResetWindow ();

			Destroy (this.gameObject);
			sc.Play_atk_Sound ();


		} else if (col.tag == "PlayerLife") {
			Application.LoadLevel ("Gameover");
			sc.Play_die_Sound ();

			//Debug.Log ("hit enemy .. damage");
		}
		
	}
}
