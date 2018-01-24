using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapBottle : MonoBehaviour {

	public ParticleSystem theSparkle = new ParticleSystem ();
	// Use this for initialization
	void Start () 
	{
		theSparkle = GetComponentInChildren<ParticleSystem>();
		theSparkle.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SanitiseHands()
	{
		SoundManager.instance.PlaySoundHover("SparkleII");
		theSparkle.Stop ();
		theSparkle.Play ();
		//theSparkle.gameObject.SetActive (true);
	}
}
