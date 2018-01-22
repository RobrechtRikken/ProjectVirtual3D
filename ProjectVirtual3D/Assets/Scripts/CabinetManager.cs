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
	public List<GameObject> medicineList = new List<GameObject>();
	public List<GameObject> drawerSlotList = new List<GameObject>();
	public int cabinetDrawerId;
	public Cabinet theCabinet;
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
				//Debug.Log(drawer.name + " added to array [" +i + "," + j + "]"); 
				j++;
			}
			j = 0;
		}
		//Debug.Log ("All drawers added to array");
	}


	public void InitiateVanas()
	{
		Debug.Log ("INITIATING VANAS");
		//Get all the medicine from the XML file into the VANAS
		for (int i = 0; i < amountOfCabinets; i++) 
		{
			for (int j = 0; j < amountOfDrawersInCAbinet; j++) 
			{
				theCabinet = MedicalAppDataManager.instance.MedicalAppData.mCabinets[i];
				Debug.Log (theCabinet.mDrawers.Count);
				cabinetDrawerId = theCabinet.mDrawers[j];
				CabinetDrawer theCabinetDrawer = MedicalAppDataManager.instance.MedicalAppData.mDrawers.Find (o => o.mID == cabinetDrawerId); 
				if (theCabinetDrawer == null) {
					//Drawer is empty , next drawer
				//	Debug.Log ("Drawer does not exist");
				} 
				else 
				{
					if (theCabinetDrawer.mMedicines.Count == 0) {
						//Do nothing , move on tho next drawer
					//	Debug.Log ("Drawer empty next drawer");
					} 
					else 
					{
						//CREATE SPAWNLIST FOR THIS DRAWER ONCE
						Transform[] allChildren =drawerArray[i,j].GetComponentsInChildren<Transform>();
						foreach (Transform child in allChildren) 
						{
						//	Debug.Log ("the child we are checking for a slotTag is : " + child.name);
							if (child.tag == drawerSlotTag) 
							{
								drawerSlotList.Add (child.gameObject);
								//Debug.Log (child.name + " added to possible spawnlocationlist");
							}
						}

						//There are medicines in this drawer
						//Debug.Log ("Medicines are in the drawer || AMOUNT = " + theCabinetDrawer.mMedicines.Count);
						foreach (int medicine in theCabinetDrawer.mMedicines) 
						{
							//Debug.Log (medicine + " = Id of medicine in drawer");
							int randomPos = Random.Range (0, drawerSlotList.Count);
							GameObject newMedicine = Instantiate(medicineList[medicine], drawerSlotList [randomPos].transform.position, Quaternion.identity);
							Debug.Log (newMedicine + " Spawned in position " + drawerSlotList[randomPos].name);
							drawerSlotList.RemoveAt(randomPos);

						}
					}
				}
			}
		}
	}

}
