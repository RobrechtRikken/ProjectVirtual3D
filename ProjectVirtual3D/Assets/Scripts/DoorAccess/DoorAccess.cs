using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class DoorAccess : MonoBehaviour
{
	private float time;
	[SerializeField] private float timeToCheck = 1f;
	[SerializeField] private float timeToEnter = 3f;
	[SerializeField] private string tagNameBadge = "Badge";
	[SerializeField] private GameObject screen; //the screen of the access control
	[SerializeField] private GameObject door; //The door that's associated with the access control
	public Material screenBaseColor;
	public Material screenAccesDeniedColor;
	public Material screenAccesGrantedColor;


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRIGGERED");
	}

	//If the badge stays in the trigger for X seconds we want to unlock the door for X seconds
	//After the door has been unlocked for X seconds we lock it again
	void OnTriggerStay(Collider other)
	{
		time += Time.deltaTime;
		
		if (time >= timeToCheck)
		{
			if (other.tag == tagNameBadge) //Check the tag of the object, we only want our badge to grant access
			{
				UnlockDoor(door);
			}
			else
			{
				DenyAccess();
			}
		}
	}

	//if the badge leaves the trigger zone we want to reset the counter
	void OnTriggerExit(Collider other)
	{
		time = 0;
		StartCoroutine(ResetScreen(timeToEnter));
		Debug.Log("Trigger Exit");
	}

	//Unlock the door, update screen color
	void UnlockDoor(GameObject _door)
	{
		if (screen != null)
		{
			screen.GetComponent<MeshRenderer>().material = screenAccesGrantedColor;
		}

		//Activate script on door

		//After X seconds deactivate script on door
	}

	//turn the screen back to it's normal color after X seconds
	IEnumerator ResetScreen(float _timeToWait)
	{
		yield return new WaitForSeconds(_timeToWait);
		if (screen != null)
		{
			screen.GetComponent<MeshRenderer>().material = screenBaseColor;
		}
	}

	void DenyAccess()
	{
		if (screen != null)
		{
			screen.GetComponent<MeshRenderer>().material = screenAccesDeniedColor;
		}
	}
	
}
