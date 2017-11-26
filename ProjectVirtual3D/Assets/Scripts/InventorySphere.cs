using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySphere : MonoBehaviour {

	public Inventory inventoryRef;
	private string itemTag = "Item";
	// Use this for initialization
	void Start () 
	{
		inventoryRef = GetComponentInParent<Inventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//CHeck every object that enters the inventorySphere
	public void OnTriggerEnter (Collider col)
	{
		//If the item entering the sphere is actually an item that can be put in your inventory, give the item to the inventory script of the parent
		if (col.gameObject.tag == itemTag) {
			inventoryRef.AddItemToInventory (col.gameObject);
		} 
		else 
		{
			Debug.Log (col.gameObject + " does not have the tag " + itemTag);
		}
	}
}
