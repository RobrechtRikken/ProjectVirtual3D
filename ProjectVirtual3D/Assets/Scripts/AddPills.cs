using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class AddPills : MonoBehaviour {

	public VRTK_SnapDropZone[] dropZoneList;
	public GameObject pillPrefab;
	// Use this for initialization
	void Start () {
		foreach(VRTK_SnapDropZone oneDropZone in dropZoneList)
		{
			GameObject newPill = Instantiate (pillPrefab,oneDropZone.transform.position, oneDropZone.transform.rotation);
			oneDropZone.ForceSnap (newPill);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
