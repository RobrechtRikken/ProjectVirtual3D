using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Inventory2 : MonoBehaviour 
{
	public GameObject inventory;
	public GameObject securityBadge;

	// Use this for initialization
	void Start () 
	{
		GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(ShowInventory);
		inventory.gameObject.SetActive (false);
		securityBadge.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowInventory(object sender, ControllerInteractionEventArgs e)
	{
		//When the touchpad is clicked on this controller (inventory controller) check if the bottom or top half is clicked
		//TOP HALF = open inventory
		if (e.touchpadAxis.y > 0.1) 
		{
			Debug.Log ("Top of touchpad of " + this.name + " is clicked");
			if (inventory.activeSelf) 
			{
				inventory.SetActive (false);
			} 
			else 
			{
				securityBadge.SetActive (false);
				inventory.SetActive (true);
			}
		}
		//Bottom half of the touchpad will show badge and remove inventory if open
		if (e.touchpadAxis.y < -0.1) 
		{
			Debug.Log ("Bottom of touchpad of " + this.name + " is clicked");
			if (!securityBadge.activeSelf) {
				inventory.SetActive (false);
				securityBadge.SetActive (true);
			}
			else 
			{
				securityBadge.SetActive (false);
			}
		}

	}
}
