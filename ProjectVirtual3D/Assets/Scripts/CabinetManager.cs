using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManager : MonoBehaviour {
	private int amountOfCabinets = 5;
	private int amountOfDrawersInCAbinet = 7;
	public string drawerTag = "Drawer";
	public string drawerSlotTag = "DrawerSlot";
	public string cabinetTag = "Cabinet";
	public List<GameObject> cabinetList = new List<GameObject>();
	public bool anyDrawerUnlocked = false;
	public GameObject lastDrawer;
	public GameObject[,] drawerArray;
	// Use this for initialization
	void Start () 
	{	//INITIALISE DRAWER ARRAY
		drawerArray = new GameObject[amountOfCabinets,amountOfDrawersInCAbinet];
		//Gets all cabinets in the scene and adds them to this list
		for (int i = 0; i < amountOfCabinets; i++) 
		{
			cabinetList.Add(GameObject.FindGameObjectWithTag(cabinetTag + i.ToString()));
			Debug.Log (GameObject.FindGameObjectWithTag (cabinetTag + i.ToString ()).name + " added to cabinet list");
		}
		//Adds drawers for each cabinet in the array
		for (int i = 0; i < amountOfCabinets; i++) 
		{//Cycle through all cabinets
			int j = 0;
			foreach (Transform drawer in cabinetList[i].transform) 
			{//Cycle through all drawers in that cabinet (cabinet[i]
				drawerArray [i, j] = drawer.gameObject;
				Debug.Log(drawer.name + " added to array [" +i + "," + j + "]"); 
				j++;

			}
			j = 0;
		}
		Debug.Log ("All drawers added to array");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

}
