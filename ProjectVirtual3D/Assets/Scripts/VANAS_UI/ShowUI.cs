using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
	
	public void SelectPatient()
	{
		PatientManager.instance.SetSelectedPatient();
	}
}
