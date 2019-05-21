using UnityEngine;
using System.Collections;

public class EnemyCollider : MonoBehaviour
{
	GameObject PlayerAttackColliderObj;
	GameObject EnemyObj;
	public bool HitButton;
	public float AttackTime;
	float counter;
	// Use this for initialization
	void Start ()
	{
		PlayerAttackColliderObj = GameObject.Find ("attackCollider");
		EnemyObj = GameObject.FindGameObjectWithTag ("Enemy");

		PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled = false;
		//PlayerAttackColliderObj.GetComponentInChildren<BoxCollider2D> ().enabled = false;
		HitButton = false;
		AttackTime = 0.6f;
		counter = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		HitButton = Input.GetKeyDown (KeyCode.Mouse0);
		//Debug.Log ("attack counter" + counter);

		if (PlayerController._Hit) {
			//PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled = true;
			PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled = true;
		}
		if (PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled == true) {
			counter += Time.deltaTime;

			if (counter > AttackTime) {
				PlayerAttackColliderObj.GetComponent<BoxCollider2D> ().enabled = false;
				counter = 0;
				PlayerController._Hit = false;
			}
		}
	}

	

}
