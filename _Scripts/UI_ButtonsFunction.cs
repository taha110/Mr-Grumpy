using UnityEngine;
using System.Collections;

public class UI_ButtonsFunction : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void LevelSnow ()
	{
		Application.LoadLevel ("Level Snow");
	}
	public void LevelDesert ()
	{
		Application.LoadLevel ("Level Desert");

	}
	public void LevelCity ()
	{
		Application.LoadLevel ("Level City");

	}
	public void LevelJungle ()
	{
		Application.LoadLevel ("Level Jungle");

	}
}
