using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision col)
	{
		Debug.Log ("this is colliding with " + this.gameObject.name + " : " + col.gameObject.name);
	}
}
