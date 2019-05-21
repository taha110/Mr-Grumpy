using UnityEngine;
using System.Collections;

public class VibrationControler : MonoBehaviour
{

	public static bool _VibrateOn = true;

	// Use this for initialization
	void Start ()
	{
		_VibrateOn = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void VibrationOnOff ()
	{
		if (_VibrateOn == true) {
			_VibrateOn = false;
		} else {
			_VibrateOn = true;
			Handheld.Vibrate ();
		}

	}




}
