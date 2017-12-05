using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LoadMedicineList : MonoBehaviour
{

	public int patientAmount; //How many patients
	[SerializeField] private List<string> patientList = new List<string>();
	private string[] names = new string[] {"Dafalgan", "Amoxicilline", "Hydrochlorothiazide ", "Omeprazole", "Lisinopril ","Simvastatine"};
	private string[] grams = new string[] { "50mg", "100mg", "200mg", "500mg"};
	public Transform MedicnineListTransform;
	public GameObject prefabMedicinePanel;

	public List<string> PatientList
	{
		get { return patientList; }
	}

	// Use this for initialization
	void Start ()
	{
		string newName = "";
		for (int i = 0; i < patientAmount; i++)
		{
			newName = RandomName();
			if (patientList.Contains(newName))
			{
				newName = RandomName();
			}
			patientList.Add(newName);
			AddRow(newName);
		}

	}

	string RandomName()
	{
		return names[(int)Random.Range(0f, 5f)] + " " + grams[(int) Random.Range(0f, 3f)];
	}

	void AddRow(string _namePatient)
	{
		//Instantiate(prefabPatientPanel, patientListTransform.transform.position, patientListTransform.transform.rotation);


		GameObject newRow = Instantiate(prefabMedicinePanel,MedicnineListTransform);
		newRow.transform.GetChild(0).GetComponent<Text>().text = _namePatient;


	}
}
