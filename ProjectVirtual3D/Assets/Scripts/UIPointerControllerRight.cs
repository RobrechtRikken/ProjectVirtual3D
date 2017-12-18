using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UIPointerControllerRight : MonoBehaviour {

	public VRTK_Pointer BezierPointer;
	public VRTK_Pointer UIPointer;
	// Use this for initialization
	void Start () 
	{
		
	}


	public void whenPointerEntersUI()
	{
		Debug.Log ("Entered a UI canvas");
		BezierPointer.enabled = !BezierPointer.enabled;
		UIPointer.enabled = !UIPointer.enabled;
	}

	public void whenPointerLeavesUI()
	{
		Debug.Log ("Left a Ui canvas");
		BezierPointer.enabled = !BezierPointer.enabled;
		UIPointer.enabled = !UIPointer.enabled;
	}
}
