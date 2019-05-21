using UnityEngine;
using System.Collections;

public class FootprintPrefabScript : MonoBehaviour
{

	public Vector3 velocity;
	Transform position;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!IngameUI._pause) {
			transform.position += velocity;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "footstopper") {
			Destroy (this.gameObject);
		}
	}
}
