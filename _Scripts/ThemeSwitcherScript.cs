using UnityEngine;
using System.Collections;

public class ThemeSwitcherScript : MonoBehaviour
{

	public string selectedTxt;
	public Camera GOCam;

	RaycastHit hitObject;
	Ray rayObjLevels;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.Mouse0)) {
			selectedTxt = "";
			rayObjLevels = GOCam.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (rayObjLevels, out hitObject)) {
				selectedTxt = hitObject.collider.name;
			}
			
			//if(selectedTxt.Contains("Level")) Application.LoadLevel(selectedTxt);
			switch (selectedTxt) {
			case "go_desert":
				Application.LoadLevel ("Level Desert");
				break;
			case "exit":
				Application.Quit ();
				break;

			}
			
		}
	}
}
