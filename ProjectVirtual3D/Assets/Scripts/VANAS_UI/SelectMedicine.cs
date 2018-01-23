using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMedicine : MonoBehaviour {

	private string nameMedicine;

	public void SelectMedicineFromList()
	{
		nameMedicine = GetComponentInChildren<Text>().text;
		PatientManager.instance.SetSelectedMedicine(nameMedicine);
	}

	public void SelectAnotherMedicine()
	{
		nameMedicine = GetComponentInChildren<Text>().text;
		PatientManager.instance.SelectAnotherMedicine();
	}

	public void ExitVanas()
	{
		PatientManager.instance.ExitVANAS ();
	}
}
