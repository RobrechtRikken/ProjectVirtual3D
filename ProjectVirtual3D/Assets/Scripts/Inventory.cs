using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Inventory : MonoBehaviour {
	//List to hold all inventory objects
	public List<GameObject> InventoryStorage;
	public GameObject inventorySphere;
	public GameObject inventoryScreen;
	public GameObject[] inventorySlots;
	private float inventoryScaleDown = 2;
	private string inventorySlotTag = "InventorySlot";
	// Use this for initialization
	void Start () 
	{
		GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(ShowInventoryOrSphere);
		InventoryStorage = new List<GameObject>();
		inventorySlots = GameObject.FindGameObjectsWithTag (inventorySlotTag);
		//Set the inventory to false after the slots have been added toth e list
		inventoryScreen.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItemToInventory(GameObject itemtoAdd)
	{
		Debug.Log ("Adding " + itemtoAdd + " to the inventory");
		//Adds the item to the InventoryStorage List and removes it from the scene
		InventoryStorage.Add(itemtoAdd);
		Debug.Log ("Added " + itemtoAdd + " to the inventory");
		MoveItemToSlot (itemtoAdd);
		//Destroy (itemtoAdd);
	}
	//Move the added object to a predefined place in your inventory
	public void MoveItemToSlot(GameObject ObjectToAdd)
	{Debug.Log ("Moving item to slot");
		//check for empty inventory slot while scrolling through all inventoryslots
		for (int i = 0; i < inventorySlots.Length; i++) 
		{
			Debug.Log (inventorySlots [i].gameObject.name + " has this amount of children : " + inventorySlots [i].transform.childCount);
			if (inventorySlots [i].transform.childCount <= 0) 
			{
				Debug.Log ("Empty slot found, it is : " + inventorySlots [i].gameObject.name);
				ObjectToAdd.transform.localScale = new Vector3 (ObjectToAdd.transform.localScale.x / inventoryScaleDown, ObjectToAdd.transform.localScale.y / inventoryScaleDown, ObjectToAdd.transform.localScale.z / inventoryScaleDown);
				ObjectToAdd.transform.SetParent (inventorySlots [i].transform);
				ObjectToAdd.GetComponent<Rigidbody> ().isKinematic = true;
				ObjectToAdd.transform.rotation = new Quaternion (0, 0, 0, 0);
				ObjectToAdd.transform.localPosition = new Vector3 (0, 0, 0); 
			}
		}
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
				inventoryScreen.SetActive (false);
				inventorySphere.SetActive (true);				
			}
		}
		//Bottom half of the touchpad will show your inventory with all the items added inside
		if (e.touchpadAxis.y < -0.1) 
		{
			Debug.Log ("Bottom of touchpad of " + this.name + " is clicked");
			if (inventoryScreen.activeSelf) 
			{
				inventoryScreen.SetActive (false);
			} 
			else 
			{
				inventorySphere.SetActive (false);
				inventoryScreen.SetActive (true);				
			}
		}

	}
}
