using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorV2 : MonoBehaviour 
{
	public bool doorOpen = false;
	public float rotationSpeed = 1f;

	public void ToggleDoor()
	{
		Debug.Log ("Door is used");
		if (!doorOpen) 
		{
			Debug.Log ("Door is now open");
			transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime));
			doorOpen = true;
		}
		else 
		{
			Debug.Log ("Door is now closed");
			transform.Rotate (-Vector3.up * (rotationSpeed * Time.deltaTime));
			doorOpen = false;
		}
	}

}
