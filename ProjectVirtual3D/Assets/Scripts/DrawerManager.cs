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
	public GameObject[] drawerList;
	private float OpenedDrawerDistance = -0.84f;
	private float closedDrawerDistance = 0f;
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

	public void OpenARandomDrawer()
	{
		OpenDrawer(drawerList[(int)GetRandomDrawer()]);
		Debug.Log("this is the random drawer that's going to be open : " + drawerList[(int)GetRandomDrawer()].name);
	}

	private void OpenDrawer(GameObject openingDrawer)
	{
		//Open the drawer and start blinking the light
		VRTK_PhysicsSlider theDrawer = openingDrawer.GetComponent<VRTK_PhysicsSlider>();
		theDrawer.maximumLength = OpenedDrawerDistance;
		theDrawer.enabled = false;
		theDrawer.enabled = true;
		ToggleLight (openingDrawer);
	}
	public void ToggleLight(GameObject selectedDrawer)
	{
		//This will toggle the light
	}

	public void LockDrawer (GameObject closingDrawer)
	{
		//close the drawer and stop blinking the light
		VRTK_PhysicsSlider theDrawer = closingDrawer.GetComponent<VRTK_PhysicsSlider> ();
		theDrawer.maximumLength = closedDrawerDistance;
		theDrawer.enabled = false;
		theDrawer.enabled = true;
		ToggleLight (closingDrawer);
	}
}