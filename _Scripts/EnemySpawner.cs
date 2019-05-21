using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

	float counter = 0;
	float checker = 0;
	public GameObject EnemyOneObj;
	public GameObject EnemyTwoObj;
	public GameObject EnemyThreeObj;

	public GameObject ObstacleOneObj;
	public GameObject ObstacleTwoObj;
	public GameObject ObstacleThreeObj;
	public GameObject ObstacleFourObj;

	int enemyNumber;

	// Use this for initialization
	void Start ()
	{
		enemyNumber = Random.Range (0, 7);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (checker >= counter) {

			if (enemyNumber == 0) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyOneObj, new Vector3 (30f, -3f, -0.5f), transform.rotation);
				checker = 0;

			} else if (enemyNumber == 1) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyTwoObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;

			} else if (enemyNumber == 2) {
				GameObject cubeSpawn = (GameObject)Instantiate (EnemyThreeObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;

			} else if (enemyNumber == 3) {
				GameObject cubeSpawn = (GameObject)Instantiate (ObstacleOneObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;

			} else if (enemyNumber == 4) {
				GameObject cubeSpawn = (GameObject)Instantiate (ObstacleTwoObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;
			} else if (enemyNumber == 5) {
				GameObject cubeSpawn = (GameObject)Instantiate (ObstacleThreeObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;

			} else if (enemyNumber == 6) {
				GameObject cubeSpawn = (GameObject)Instantiate (ObstacleFourObj, new Vector3 (30f, -2.2f, -0.5f), transform.rotation);
				checker = 0;

			}

			counter = Random.Range (6f, 7f);
		}


		enemyNumber = Random.Range (0, 7);
		checker += Time.deltaTime;

		//Debug.Log ("enemy num  : " + enemyNumber);
		//Debug.Log ("enemy num  : " + enemyNumber);
	}
}
