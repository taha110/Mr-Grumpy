using UnityEngine;
using System.Collections;

public class BillingScript : MonoBehaviour
{


	public static int _HeartsToBuy;

	// Use this for initialization
	void Start ()
	{
		_HeartsToBuy = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public void HeartsBuyTen ()
	{
		_HeartsToBuy = 10;
		//	GameBillingManagerExample.COINS_ITEM = "10hearts";
	}

	
	public void HeartsBuyFifty ()
	{
		_HeartsToBuy = 50;
		//	GameBillingManagerExample.COINS_ITEM = "50hearts";

	}

	
	public void HeartsBuyHundread ()
	{
		_HeartsToBuy = 100;
		//	GameBillingManagerExample.COINS_ITEM = "100hearts";

	}
}
