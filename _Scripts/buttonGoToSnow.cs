using UnityEngine;
using System.Collections;

public class buttonGoToSnow : MonoBehaviour
{
	int temp;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			temp = (int)Random.Range (0, 4);
			if (temp == 0) {
				Application.LoadLevel ("Level Snow");
			} else if (temp == 1) {
				Application.LoadLevel ("Level Desert");
			} else if (temp == 2) {
				Application.LoadLevel ("Level City");
			} else if (temp == 3) {
				Application.LoadLevel ("Level Jungle");
			}


			Time.timeScale = 1;
			IngameUI._pause = false;
		}
	}
}
