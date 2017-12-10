using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class LoadPatientsList : MonoBehaviour
{

	public int patientAmount; //How many patients
	[SerializeField] private List<string> patientList = new List<string>();
	private string[] voornamen = new string[] {"Robin", "Stijn", "Anouk", "Stephanie", "Tim","Rene","Charlotte","Ludwig","Hilde","Philippe","Marjolien","Melissa","Marijke"};
	private string[] achternamen = new string[] { "Peeters", "Van den Acker", "Rikken", "De Houwer", "Baetens", "De Baere","Van Elshocht","Janssens","Mertens","Maes","Jacobs","Willems","De Vos" };
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

	string RandomName()
	{
		return achternamen[(int)Random.Range(0f, 12f)] + " " + voornamen[(int) Random.Range(0f, 12f)];
	}

	void AddRow(string _namePatient)
	{
		//Instantiate(prefabPatientPanel, patientListTransform.transform.position, patientListTransform.transform.rotation);


		GameObject newRow = Instantiate(prefabPatientPanel,patientListTransform);
		newRow.transform.GetChild(0).GetComponent<Text>().text = _namePatient;


	}

	void LoadPatients()
	{
		/*string newName = "";
		for (int i = 0; i < patientAmount; i++)
		{
			newName = RandomName();
			if (patientList.Contains(newName))
			{
				newName = RandomName();
			}
			patientList.Add(newName);
			AddRow(newName);
		}*/

		//Hardcoding some patient here -- load data from XML and make a Patient instance out of them

		Patient patient1 = new Patient(1,"Stijn", "Getteman", 26, 64, "Man", new List<string>() {"Value 1","Value 2"}, 
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" });

		Patient patient2 = new Patient(2,"Robin", "Rikken", 22, 75, "Man", new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" });

		Patient patient3 = new Patient(3,"Anne", "Mertens", 38, 62, "Vrouw", new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" });

		Patient patient4 = new Patient(4,"Sandra", "Claessens", 15, 40, "Vrouw", new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" });

		PatientManager.instance.AddPatient(patient1);
		PatientManager.instance.AddPatient(patient2);
		PatientManager.instance.AddPatient(patient3);
		PatientManager.instance.AddPatient(patient4);

		AddRow(patient1.FirstName + " " + patient1.LastName);
		AddRow(patient2.FirstName + " " + patient2.LastName);
		AddRow(patient3.FirstName + " " + patient3.LastName);
		AddRow(patient4.FirstName + " " + patient4.LastName);

	}

}
