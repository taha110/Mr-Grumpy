using UnityEngine;
using System.Collections;

public class Enemys : MonoBehaviour {

	// Use this for initialization
	public Texture[] enemyTexture;
	public float textureCount;
	public Material enemyMaterial;
	public float enemySpeed=20;
	public bool isTrue=false;

	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		//if (isTrue) {
						if (textureCount > enemyTexture.Length - 1)textureCount = 0;

						enemyMaterial.mainTexture = enemyTexture [Mathf.RoundToInt (textureCount)];
						textureCount += enemySpeed * Time.deltaTime;

						if (textureCount > enemyTexture.Length)
								textureCount = 0;
				//}
	
	}
	void OnBecameVisible() {
				isTrue = true;
		}

}
