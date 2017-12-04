using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePatientList : MonoBehaviour
{

	public LoadPatientsList patientList;
	public Transform patientlistParent;

	public void ShowPatient(Text inputText)
	{
		//Debug.Log("Update list");


		//Transform[] allChildren = patientlistParent.transform.GetComponentsInChildren<Transform>();
		foreach (Transform child in patientlistParent)
		{
			
			// do whatever with child transform here
				//Debug.Log (child.name);
				if (child.transform.GetChild (0).GetComponent<Text> ().text.Contains(inputText.text)) {
					child.transform.gameObject.SetActive (true);
				} else {
					child.transform.gameObject.SetActive (false);
				}
		}
		Debug.Log (inputText.text);
	}
}
