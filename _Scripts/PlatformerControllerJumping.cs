using UnityEngine;
using System.Collections;

public class PlatformerControllerJumping : MonoBehaviour {
	 
	public 	bool enabled= true;
	
	// How high do we jump when pressing jump and letting go immediately
	public float height= 1.0f;
	// We add extraHeight units (meters) on top when holding the button down longer while jumping
	public float extraHeight= 4.1f;
	
	public float doubleJumpHeight= 2.1f;
	
	// This prevents inordinarily too quick jumping
	// The next line,  , tells Unity to not serialize the variable or show it in the inspector view.  Very handy for organization!
	
	public float repeatTime= 0.05f;
	
	
	public float timeout= 0.15f;
	
	// Are we jumping? (Initiated with jump button and not grounded yet)
	
	public		bool jumping= false;
	
	// Are where double jumping? ( Initiated when jumping or falling after pressing the jump button )
	
	public	bool doubleJumping= false;
	
	// Can we make a double jump ( we can't make two double jump or more at the same jump )
	
	public	bool canDoubleJump= false;
	
	
	public	bool reachedApex= false;
	
	// Last time the jump button was clicked down
	
	public float lastButtonTime= -10.0f;
	
	// Last time we performed a jump
	
	public float lastTime= -1.0f;
	
	// the height we jumped from (Used to determine for how long to apply extra jump power after jumping.)
	
	public float lastStartHeight= 0.0f;
}
