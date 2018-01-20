using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
	[SerializeField]
	private float timeToBlink = 3f; //blink the "check to your left" text for X seconds when entering
	public float blinkIntervals = 0.5f;
	[SerializeField]
	private GameObject blinkObject;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(BlinkOnOff(timeToBlink));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator BlinkOnOff(float _waitTime)
	{
		float endTime = Time.time + _waitTime;
		while (Time.time < endTime)
		{
			blinkObject.SetActive(true);
			yield return new WaitForSeconds(blinkIntervals);
			blinkObject.SetActive(false);
			yield return new WaitForSeconds(blinkIntervals);

		}
	}
}
