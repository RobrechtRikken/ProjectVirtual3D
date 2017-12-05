using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using VRTK.GrabAttachMechanics;

public class DrawerManager : MonoBehaviour {
	//2 tags you need to find all drawers and all drawerslots once you have selected one drawer
	public string drawerTag = "Drawer";
	public string drawerSlotTag = "DrawerSlot";
	public string drawerLightTag = "DrawerLight";
	public GameObject[] drawerList;
	public Material drawerLightON;
	public Material drawerLightOff;
	private float OpenedDrawerDistance = -0.84f;
	private float closedDrawerDistance = 0f;
	public bool lightBool = false;
	public bool drawerUnlocked = false;
	private GameObject lastDrawer;
	// Use this for initialization
	void Start () 
	{
		//find all drawers in the scene so that they are in a list
		drawerList = GameObject.FindGameObjectsWithTag(drawerTag);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private float GetRandomDrawer()
	{
		return Random.Range (0, drawerList.Length);
	}

	public void Reset()
	{
		ToggleLight (lastDrawer);
		lightBool = false;
		drawerUnlocked = false;

	}
	public void OpenARandomDrawer()
	{
		if (!drawerUnlocked) 
		{
			drawerUnlocked = true;
			StartCoroutine (OpenDrawer (drawerList [(int)GetRandomDrawer ()]));
			Debug.Log ("this is the random drawer that's going to be open : " + drawerList [(int)GetRandomDrawer ()].name);
		}
	}

	private IEnumerator OpenDrawer(GameObject openingDrawer)
	{
		//Open the drawer and start blinking the light
		VRTK_PhysicsSlider theDrawer = openingDrawer.GetComponent<VRTK_PhysicsSlider>();
		theDrawer.maximumLength = OpenedDrawerDistance;
		theDrawer.enabled = false;
		yield return new WaitForSeconds(1f);
		theDrawer.enabled = true;
		ToggleLight (openingDrawer);
		lastDrawer = openingDrawer;
	}
	public void ToggleLight(GameObject selectedDrawer)
	{
		//This will toggle the light
		/*foreach(Transform child in selectedDrawer.transform)
		{
			if (child.gameObject.tag == drawerLightTag) 
			{
				Debug.Log (child.gameObject.GetComponent<MeshRenderer> ().material.name);
				Debug.Log(drawerLightOff.name);
				if (child.gameObject.GetComponent<MeshRenderer>().material.name == drawerLightOff.name) 
				{
					child.gameObject.GetComponent<MeshRenderer>().material = drawerLightON;
				} 
				else 
				{
					Debug.Log ("Light is now turned off");
					child.gameObject.GetComponent<MeshRenderer> ().material = drawerLightOff;
				}

			}
		}*/

		foreach (Transform child in selectedDrawer.transform) {
			if (child.gameObject.tag == drawerLightTag) {
				
				if (!lightBool) {
					child.gameObject.GetComponent<MeshRenderer> ().material = drawerLightON;
					lightBool = !lightBool;
				} else {
					Debug.Log ("Light is now turned off");
					child.gameObject.GetComponent<MeshRenderer> ().material = drawerLightOff;
					lightBool = !lightBool;
				}
			}
		}
		
	}

	public void LockDrawer (GameObject closingDrawer)
	{
		//close the drawer and stop blinking the light
		VRTK_PhysicsSlider theDrawer = closingDrawer.GetComponent<VRTK_PhysicsSlider> ();
		theDrawer.maximumLength = closedDrawerDistance;
		theDrawer.enabled = false;
		theDrawer.enabled = true;
		ToggleLight (closingDrawer);
		drawerUnlocked = false;
	}
}