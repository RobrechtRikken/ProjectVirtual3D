using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCubeScript : MonoBehaviour {
	public CabinetManager testCabinetManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void testMethod()
	{
		Debug.Log ("TEST METHOD BOOTING");
		testCabinetManager.OpenDrawer (1, 0);
	}


}
