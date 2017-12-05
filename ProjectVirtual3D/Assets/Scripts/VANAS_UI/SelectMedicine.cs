using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMedicine : MonoBehaviour {

	public void SelectMedicineFromList()
	{
		PatientManager.instance.SetSelectedMedicine();
	}
}
