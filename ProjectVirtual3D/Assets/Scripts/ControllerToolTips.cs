using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerToolTips : MonoBehaviour 
{

	public float toolTipShowTimer = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		toolTipShowTimer -= Time.deltaTime;
		if (toolTipShowTimer <= 0) {
			this.gameObject.SetActive (false);
		} 
		else 
		{
			this.gameObject.SetActive (true);
		}
		
	}

	public void ShowToolTips()
	{
		toolTipShowTimer = 10f;
	}
}
