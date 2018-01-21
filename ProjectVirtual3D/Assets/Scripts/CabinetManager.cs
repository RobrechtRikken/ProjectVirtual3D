using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManager : MonoBehaviour {
	private int amountOfCabinets = 5;
	public string drawerTag = "Drawer";
	public string drawerSlotTag = "DrawerSlot";
	public string cabinetTag = "Cabinet";
	public List<GameObject> cabinetList = new List<GameObject>();
	// Use this for initialization
	void Start () 
	{	
		for (int i = 0; i < amountOfCabinets; i++) 
		{
			cabinetList.Add(GameObject.FindGameObjectWithTag(cabinetTag + i.ToString()));
			Debug.Log (GameObject.FindGameObjectWithTag (cabinetTag + i.ToString ()).name + " added to cabinet list");
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
