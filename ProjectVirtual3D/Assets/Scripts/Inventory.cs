using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Inventory : MonoBehaviour {
	//List to hold all inventory objects
	private List<GameObject> InventoryStorage;
	public GameObject inventorySphere;
	// Use this for initialization
	void Start () 
	{
		GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(ShowInventoryOrSphere);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItemToInventory(GameObject itemtoAdd)
	{
		//Adds the item to the InventoryStorage List and removes it from the scene
		InventoryStorage.Add(itemtoAdd);
		Destroy (itemtoAdd);
	}

	public void ShowInventoryOrSphere(object sender, ControllerInteractionEventArgs e)
	{
		//When the touchpad is clicked on this controller (inventory controller) check if the bottom or top half is clicked
		//Top half will result in the enabling of your inventory shpere which will allow the adding of items to the inventory
		if (e.touchpadAxis.y > 0.1) 
		{
			Debug.Log ("Top of touchpad of " + this.name + " is clicked");
			if (inventorySphere.activeSelf) 
			{
				inventorySphere.SetActive (false);
			} 
			else 
			{
				inventorySphere.SetActive (true);				
			}
		}
		//Bottom half of the touchpad will show your inventory with all the items added inside
		if (e.touchpadAxis.y < -0.1) 
		{
			Debug.Log ("Bottom of touchpad of " + this.name + " is clicked");
		}

	}
}
