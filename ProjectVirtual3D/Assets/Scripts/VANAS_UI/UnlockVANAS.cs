using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UnlockVANAS : MonoBehaviour
{
	private float time;
	[SerializeField]
	private float timeToCheck = 1f;
	[SerializeField]
	private float timeToEnter = 3f;
	[SerializeField]
	private float timeToBlink = 3f; //blink the "check to your left" text for X seconds when entering

	public float blinkIntervals;
	[SerializeField]
	private string tagNameBadge = "Badge";
	[SerializeField]
	private GameObject screen; //the screen of the access control
	[SerializeField]
	private GameObject door; //The door that's associated with the access control
	[SerializeField]
	private GameObject unlockText;
	public Material screenBaseColor;
	public Material screenAccesDeniedColor;
	public Material screenAccesGrantedColor;

	private bool alreadyOn = false;

	public GameObject patientUI;


	void OnTriggerEnter(Collider other)
	{
		Debug.Log("TRIGGERED");
	}

	//If the badge stays in the trigger for X seconds we want to unlock the door for X seconds
	//After the door has been unlocked for X seconds we lock it again
	void OnTriggerStay(Collider other)
	{

		if (other.tag == tagNameBadge) //Check the tag of the object, we only want our badge to grant access
		{
			time += Time.deltaTime;
			if (time >= timeToCheck)
			{

				AccessVanas(door);
			}
			else
			{
				//DenyAccess();
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
	void AccessVanas(GameObject _door)
	{
		if (screen != null)
		{
			if (!alreadyOn)
			{
				SoundManager.instance.PlaySound("Scan");
				screen.GetComponent<MeshRenderer>().material = screenAccesGrantedColor;
				patientUI.SetActive(true);
				StartCoroutine(Blink(timeToBlink));
				MedicalAppDataManager.instance.userChoices.Add("User scanned badge and accessed the VANAS UI");
				alreadyOn = true;

			}
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
			alreadyOn = false;
		}
	}

	IEnumerator Blink(float _waitTime)
	{
		float endTime = Time.time + _waitTime;
		while (Time.time < endTime)
		{
			unlockText.SetActive(true);
			yield return new WaitForSeconds(blinkIntervals);
			unlockText.SetActive(false);
			yield return new WaitForSeconds(blinkIntervals);
		
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
