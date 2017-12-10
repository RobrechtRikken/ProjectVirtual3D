using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
	private string name;

	public void SelectPatient()
	{
		name = GetComponentInChildren<Text>().text;
		PatientManager.instance.SetSelectedPatient(name);
	}
}
