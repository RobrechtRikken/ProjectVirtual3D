using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserToggle : MonoBehaviour {

	public GameObject theBrowser;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleBrowser()
	{
		if (theBrowser.gameObject.activeSelf) 
		{
			theBrowser.gameObject.SetActive (false);
		}
		else
		{
			theBrowser.gameObject.SetActive(true);
		}
	}
}
