using UnityEngine;
using System.Collections;

public class EnemyTransForm : MonoBehaviour {

	// Use this for initialization
	public float enemyWalkingSpeed=1;
	public Vector3 Scale;
	public GameObject particelEffect;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-1, 0, 0)*Time.deltaTime*enemyWalkingSpeed);
		Scale = transform.localScale;
	
	}
	float changedTime;
	void OnTriggerEnter( Collider trigger)
	{
		if (trigger.GetComponent<Collider>().name.Contains ("Trigger")&& Time.timeSinceLevelLoad-changedTime > 1.0f) {
			print (trigger.GetComponent<Collider>().name);
			 enemyWalkingSpeed*=-1;
			transform.localScale= new Vector3(-Scale.x,Scale.y,Scale.z);
			changedTime=Time.timeSinceLevelLoad;
				}
		}
	public void ParticelEffect()
	{
		GameObject EnemyKillEffect=Instantiate(particelEffect,gameObject.transform.position,Quaternion.identity)as GameObject;
		Destroy (EnemyKillEffect,3f);
	}
}
