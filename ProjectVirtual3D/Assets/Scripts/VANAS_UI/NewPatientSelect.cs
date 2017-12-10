using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPatientSelect : MonoBehaviour {

	public void SelectNewPatient()
	{
		PatientManager.instance.AnotherPatient();
	}
}
