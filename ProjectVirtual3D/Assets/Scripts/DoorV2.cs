using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorV2 : MonoBehaviour 
{
	public bool doorOpen = false;
	public float rotationTime;
	private Quaternion openRotation;
	private Quaternion closedRotation;
	public float openValue = 0.95f;
	private bool doorMoving = false;
	public bool inwardOutward = true;

	 void Start()
	{
		closedRotation = this.transform.rotation;
		openRotation = closedRotation;
		if (inwardOutward) {
			openRotation.y += openValue;
		} 
		else 
		{
			openRotation.y -= openValue;
		}

		rotationTime = 2f;
	}
	public void ToggleDoor()
	{
		Debug.Log ("Door is used");
		if (!doorOpen && !doorMoving) 
		{
			Debug.Log ("Door is now open");
			//transform.Rotate (Vector3.up * (rotationSpeed * Time.deltaTime));
			StartCoroutine(RotateOverTime(closedRotation, openRotation, rotationTime));
			doorOpen = true;
		}
		else 
		{
			Debug.Log ("Door is now closed");
			//transform.Rotate (-Vector3.up * (rotationSpeed * Time.deltaTime));
			StartCoroutine(RotateOverTime(openRotation, closedRotation, rotationTime));
			doorOpen = false;
		}
	}

	IEnumerator RotateOverTime (Quaternion originalRotation, Quaternion finalRotation, float duration) {
		doorMoving = true;
		if (duration > 0f) {
			float startTime = Time.time;
			float endTime = startTime + duration;
			this.transform.rotation = originalRotation;
			yield return null;
			while (Time.time < endTime) 
			{
				float progress = (Time.time - startTime) / duration;
				// progress will equal 0 at startTime, 1 at endTime.
				this.transform.rotation = Quaternion.Slerp (originalRotation, finalRotation, progress);
				yield return null;
			}
		}
			this.transform.rotation = finalRotation;
			doorMoving = false;
	}

}
