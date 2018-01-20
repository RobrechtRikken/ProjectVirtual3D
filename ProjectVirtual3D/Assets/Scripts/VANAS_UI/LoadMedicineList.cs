using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LoadMedicineList : MonoBehaviour
{

	private int medicineAmount; //How many patients
	[SerializeField] private List<string> medicineList = new List<string>();
	public Transform MedicnineListTransform;
	public GameObject prefabMedicinePanel;

	public List<string> MedicineList
	{
		get { return medicineList; }
	}


	// Use this for initialization
	void Start()
	{
		LoadMedicines();
	}

	void AddRow(string _nameMedicine)
	{
		//Instantiate(prefabPatientPanel, patientListTransform.transform.position, patientListTransform.transform.rotation);
		GameObject newRow = Instantiate(prefabMedicinePanel, MedicnineListTransform);
		newRow.transform.GetChild(0).GetComponent<Text>().text = _nameMedicine;
	}

	void LoadMedicines()
	{
		//Hardcoding some patient here -- load data from XML and make a Patient instance out of them
		foreach (Medicine medicine in MedicalAppDataManager.instance.MedicalAppData.mMedicines)
		{
			AddRow(medicine.mName + " - " + medicine.mQuantity + medicine.mUnit);
		}

	}
}
