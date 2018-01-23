using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MedicalAppDataManager : MonoBehaviour {

	// Use this for initialization
	public static MedicalAppDataManager instance = null;
	private MedicalAppData medicalAppData;
	private Scenario scenario; //holds the scenario info

	public GameObject goPatientSenior;
	public GameObject goPatientAdult;
	public GameObject goPatientPregnant;
	public GameObject goPatientChild;


	public Text firstNameText;
	public Text lastNameText;
	public Text ageText;
	public Text sexText;
	public Text weightText;
	public Text medicineText;
	public CabinetManager deManager;

	public List<string> userChoices;

	public MedicalAppData MedicalAppData
	{
		get { return medicalAppData; }
	}

	public Scenario Scenario
	{
		get { return scenario; }
	}


	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}
		
		//If instance already exists and it's not this:
		else if (instance != this)
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			WriteString();
		}
	}
	void WriteString()
	{
		string path = "EventLog.txt";
		Debug.Log("Printing file");
		//Write some text to the test.txt file
		StreamWriter writer = new StreamWriter(path, true);

		foreach (string text in userChoices)
		{
			writer.WriteLine(text);
		}
		
		writer.Close();

	}


	public void LoadAppData(MedicalAppData _loadedData)
	{
		medicalAppData = _loadedData;

		int randomScenario = Random.Range(0, medicalAppData.mScenarios.Count);
		scenario = medicalAppData.mScenarios[randomScenario];
		Debug.Log("Your scenario is " + scenario.mName);//scenario name
		Debug.Log("Your patient is " + medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).fullName);//find the patient name from the scenario
		Debug.Log("Your medicine is " + medicalAppData.mMedicines.Find(o=> o.mID == scenario.mMedicineID).mName);//find the medicine name from the scenario


		SetKlembordUI();
		ActivatePatient(medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).patientType);
		deManager.InitiateCAbinets ();
		deManager.InitiateVanas ();
	}

	void ActivatePatient(PatientType type)
	{
		switch (type)
		{
				case PatientType.senior:
				goPatientSenior.SetActive(true);
				break;
			case PatientType.adult:
				goPatientAdult.SetActive(true);
				break;
			case PatientType.child:
				goPatientChild.SetActive(true);
				break;
			case PatientType.pregnant:
				goPatientPregnant.SetActive(true);
				break;

		}
	}

	void SetKlembordUI()
	{
		firstNameText.text = medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).firstName;
		lastNameText.text = medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).lastName;
		ageText.text = medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).age.ToString();
		sexText.text = medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).sex.ToString();
		weightText.text = medicalAppData.mPatients.Find(o => o.patientID == scenario.mPatientID).weight.ToString() + " kg";

		medicineText.text = medicalAppData.mMedicines.Find(o => o.mID == scenario.mMedicineID).mName;
	}
}
