using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePatientList : MonoBehaviour
{

	public LoadPatientsList patientList;
	public Transform patienlistParent;

	public void ShowPatient(Text inputText)
	{
		Debug.Log("Update list");


		Transform[] allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren)
		{
			// do whatever with child transform here
			if (child.transform.GetChild(0).GetComponent<Text>().text.Contains(inputText.text))
			{
				child.transform.gameObject.SetActive(true);
			}
			else
			{
				child.transform.gameObject.SetActive(false);
			}
		}
	}
}
