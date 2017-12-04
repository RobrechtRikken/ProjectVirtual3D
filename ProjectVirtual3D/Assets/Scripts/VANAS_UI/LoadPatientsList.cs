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
		return achternamen[(int)Random.Range(0f, 12f)] + " " + voornamen[(int) Random.Range(0f, 12f)];
	}

	void AddRow(string _namePatient)
	{
		//Instantiate(prefabPatientPanel, patientListTransform.transform.position, patientListTransform.transform.rotation);


		GameObject newRow = Instantiate(prefabPatientPanel,patientListTransform);
		newRow.transform.GetChild(0).GetComponent<Text>().text = _namePatient;


	}
}
