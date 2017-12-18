using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UIPointerController : MonoBehaviour {

	public VRTK_Pointer dePointer;
	// Use this for initialization
	void Start () 
	{
		dePointer = this.GetComponent<VRTK_Pointer> ();
	}


	public void whenPointerEntersUI()
	{
		Debug.Log ("Entered a UI canvas");
		dePointer.enabled = true;
	}

	public void whenPointerLeavesUI()
	{
		Debug.Log ("Left a Ui canvas");
		dePointer.enabled = !dePointer.enabled;
	}
}
