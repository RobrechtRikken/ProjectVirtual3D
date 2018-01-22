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
	public Vector3 drawerStartPosition;
	public float drawerExtendPosition = -0.720f;
	public float drawerGreyExtendPosition = -0.24f;
	public float animateDuration = 2;
	public float amountOfTimeBeforeClose = 15;
	// Use this for initialization
	void Start () 
	{	
	}

	public void InitiateCAbinets()
	{
		//INITIALISE DRAWER ARRAY
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
			theCabinet = MedicalAppDataManager.instance.MedicalAppData.mCabinets[i];

			for (int j = 0; j < theCabinet.mDrawers.Count; j++) 
			{
				drawerSlotList.Clear (); //==> Declare here
				Debug.Log ("SPAWNLOCATIONLIST CLEARED FOR NEXT DRAWER");

				//if (j < theCabinet.mDrawers.Count) {
					cabinetDrawerId = theCabinet.mDrawers [j];
				//}
				CabinetDrawer theCabinetDrawer = MedicalAppDataManager.instance.MedicalAppData.mDrawers.Find (o => o.mID == cabinetDrawerId); 
				if (theCabinetDrawer == null) {
					//Drawer is empty , next drawer
				//	Debug.Log ("Drawer does not exist");
				} 
				else 
				{
					if (theCabinetDrawer.mMedicines.Count != 0)
					{
						//CREATE SPAWNLIST FOR THIS DRAWER ONCE
						Transform[] allChildren = drawerArray[i,j].GetComponentsInChildren<Transform>();
						foreach (Transform child in allChildren) 
						{
						//	Debug.Log ("the child we are checking for a slotTag is : " + child.name);
							if (child.tag == drawerSlotTag) 
							{
								drawerSlotList.Add (child.gameObject);
								//Debug.Log (child.name + " added to possible spawnlocationlist    FOR CABINET " + cabinetList[i].name );
							}
						}

						//There are medicines in this drawer
						Debug.Log ("Medicines are in the drawer || AMOUNT = " + theCabinetDrawer.mMedicines.Count);
						foreach (int medicine in theCabinetDrawer.mMedicines) 
						{
							//Debug.Log (medicine + " = Id of medicine in drawer");
							int randomPos = Random.Range (0, drawerSlotList.Count);
							//Debug.Log("RANDOM = " + randomPos + "   MAX = " + drawerSlotList.Count);
							GameObject newMedicine = Instantiate(medicineList[medicine], drawerSlotList [randomPos].transform.position, Quaternion.identity);
							Debug.Log (newMedicine + " Spawned in position " + drawerSlotList[randomPos].name);
							drawerSlotList.RemoveAt(randomPos);

						}
					}
				}
			}
		}
	}

	public void OpenDrawer(int cabinetNumber, int drawerNumber)
	{
		if (!anyDrawerUnlocked) 
		{
			//Check if cabinetnumber is 1, 2, 3 ==> Small cabinet so use drawerGreyExtendedPosition
			if (cabinetNumber == 1 || cabinetNumber == 2 || cabinetNumber == 3) 
			{
				//Start coroutine with the correct cabinet and GREY start position
				StartCoroutine(AnimateDrawer(cabinetNumber, drawerNumber, drawerGreyExtendPosition,animateDuration, amountOfTimeBeforeClose));
			} 
			else 
			{
				//Start coroutine with normal extendedposition
				StartCoroutine(AnimateDrawer(cabinetNumber, drawerNumber, drawerExtendPosition,animateDuration, amountOfTimeBeforeClose));
			}
		}
	}

	public IEnumerator AnimateDrawer(int cabinetNumber, int drawerNumber,float drawerExtended, float animateDurationDrawer, float durationToStayOpen)
	{
		//Set drawerunlocked on true so no other drawers can be open at the same time
		anyDrawerUnlocked = true;
		//Get original postition and end poition for that drawer ready
		Vector3 originalPosition = drawerArray [cabinetNumber, drawerNumber].transform.position;
		Vector3 endPosition = new Vector3 (drawerExtended, originalPosition.y, originalPosition.z);
		if (animateDurationDrawer > 0f) 
		{
			float startTime = Time.time;
			float endTime = startTime + animateDurationDrawer;
			drawerArray [cabinetNumber, drawerNumber].transform.position = originalPosition;
			yield return null;
			while (Time.time < endTime) 
			{
				float progress = (Time.time - startTime) / animateDurationDrawer;
				// progress will equal 0 at startTime, 1 at endTime.
				drawerArray [cabinetNumber, drawerNumber].transform.position = Vector3.Lerp (originalPosition, endPosition, progress);
				yield return null;
			}
		}
		drawerArray [cabinetNumber, drawerNumber].transform.position = endPosition;
		//Drawer is now open and it will close again after durationToStayOpen;
		yield return new WaitForSeconds (durationToStayOpen);
		//RESET THE ANIMATEDURATIONDRAWER SO IT STARTS BACK AT ITS ORIGINAL TIME
		animateDurationDrawer = animateDuration;
		//Drawer will now close again
		if (animateDurationDrawer > 0f) 
		{
			float startTime = Time.time;
			float endTime = startTime + animateDurationDrawer;
			drawerArray [cabinetNumber, drawerNumber].transform.position = endPosition;
			yield return null;
			while (Time.time < endTime) 
			{
				float progress = (Time.time - startTime) / animateDurationDrawer;
				// progress will equal 0 at startTime, 1 at endTime.
				drawerArray [cabinetNumber, drawerNumber].transform.position = Vector3.Lerp (endPosition, originalPosition, progress);
				yield return null;
			}
		}
		drawerArray [cabinetNumber, drawerNumber].transform.position = endPosition;
		anyDrawerUnlocked = false;
	}

}
