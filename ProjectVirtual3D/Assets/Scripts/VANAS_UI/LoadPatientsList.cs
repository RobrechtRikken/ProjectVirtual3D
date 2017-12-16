using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LoadPatientsList : MonoBehaviour
{

	public int patientAmount; //How many patients
	[SerializeField] private List<string> patientList = new List<string>();
	public Transform patientListTransform;
	public GameObject prefabPatientPanel;
	
	public List<string> PatientList
	{
		get { return patientList; }
	}

	// Use this for initialization
	void Start ()
	{
		LoadPatients();
	}

	void AddRow(string _namePatient)
	{
		//Instantiate(prefabPatientPanel, patientListTransform.transform.position, patientListTransform.transform.rotation);
		GameObject newRow = Instantiate(prefabPatientPanel,patientListTransform);
		newRow.transform.GetChild(0).GetComponent<Text>().text = _namePatient;
	}

	void LoadPatients()
	{
		//Hardcoding some patient here -- load data from XML and make a Patient instance out of them
		foreach (Patient patient in MedicalAppDataManager.instance.MedicalAppData.mPatients)
		{
			AddRow(patient.FirstName + " " + patient.LastName);
		}

	}

}
