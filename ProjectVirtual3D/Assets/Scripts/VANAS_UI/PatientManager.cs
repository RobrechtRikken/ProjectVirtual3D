﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VRTK.GrabAttachMechanics;

public class PatientManager : MonoBehaviour {

	public static PatientManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private string selectedPatient = "";
	private bool hasSelectedPatient = false;
	public GameObject patientUI, medicineUI,newMedicineUI,patientInfoUI;
	public InputField patientText, medicijnText;
	public DrawerManager drawManager;
	public GameObject vanasUI;
	private List<Patient> patientList = new List<Patient>();
	public GameObject patientInfoPrefab;

	private List<GameObject> patientInfoListToRemove = new List<GameObject>();

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		}

	void SetPatientList()
	{
	patientList = MedicalAppDataManager.instance.MedicalAppData.mPatients;
	}

	

	//Update is called every frame.
	void Update()
	{

	}

	public void AddPatient(Patient _patient)
	{
		patientList.Add(_patient);
	}
	public void SetSelectedPatient(string _selectedPatient)
	{
		if (!hasSelectedPatient)
		{
			selectedPatient = _selectedPatient;
			hasSelectedPatient = true;
			SetPatientInfo ();
			Debug.Log (selectedPatient);
			StartCoroutine (SetPatientCo ());
		}
	}

	public void SetSelectedMedicine()
	{
		StartCoroutine(UnlockDrawer());
	}

	public void SelectAnotherMedicine()
	{
		StartCoroutine(AnotherMedicine());
	}

	public void ExitVANAS()
	{
		StartCoroutine(ExitVanas());
	}

	public IEnumerator SetPatientCo()
	{
		Debug.Log("SELECT PATIENT");
		yield return new WaitForSeconds(1f);
		//set patient name here and load the patient info
		patientUI.SetActive(false);
		medicineUI.SetActive(false);
		newMedicineUI.SetActive(false);
		patientInfoUI.SetActive(true);
		medicijnText.text = "";
	}

	public IEnumerator UnlockDrawer()
	{
		//if no drawer unlocked we wait for x seconds, then we unlock the drawer with the given medicine
		//if drawer is already unlocked return

		Debug.Log("Unlock Drawer");
		yield return new WaitForSeconds(1f);
		//code to unlock drawer
		medicineUI.SetActive(false);
		newMedicineUI.SetActive(true);
		drawManager.OpenARandomDrawer();
	}

	public IEnumerator AnotherMedicine()
	{
		//drawManager.Reset();
		Debug.Log("SELECT PATIENT");
		yield return new WaitForSeconds(1f);
		newMedicineUI.SetActive(false);
		patientInfoUI.SetActive(false);
		patientUI.SetActive(false);
		medicineUI.SetActive(true);
		medicijnText.text = "";

	}

	public void AnotherPatient()
	{
		//drawManager.Reset();
		selectedPatient = "";
		hasSelectedPatient = false;
		medicijnText.text = "";
		newMedicineUI.SetActive(false);
		patientInfoUI.SetActive(false);
		medicineUI.SetActive(false);
		patientUI.SetActive(true);

		foreach (GameObject o in patientInfoListToRemove)
		{
			Destroy(o);
		}
		

	}

	public IEnumerator ExitVanas()
	{
		drawManager.Reset();
		Debug.Log("SELECT PATIENT");
		yield return new WaitForSeconds(1f);
		patientText.text = "";
		medicijnText.text = "";
		newMedicineUI.SetActive(false);
		medicineUI.SetActive(false);
		patientInfoUI.SetActive(false);
		patientUI.SetActive(true);
		vanasUI.SetActive (false);


	}

	void SetPatientInfo()
	{
		Transform[] allChildren = patientInfoUI.gameObject.GetComponentsInChildren<Transform>();

		foreach (Transform child in allChildren)
		{
		switch (child.tag)
					{
						case "FirstName":
							child.GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).firstName;
							break;
						case "LastName":
							child.GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).lastName;
							break;
						case "Age":
							child.GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).age.ToString();
							break;
						case "Sex":
							child.GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).sex.ToString();
							break;
						case "Weight":
							child.GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).weight.ToString() + " Kg";
							break;
						case "Complications":
							AddRow(child, "Complications");
							break;
						case "Allergies":
							AddRow(child, "Allergies");
					break;
						case "CurrentMedicine":
							AddRow(child, "CurrentMedicine");
							break;
						case "Prescriptions":
							AddRow(child, "Prescriptions");
							break;
						case "PreviousDosages":
							AddRow(child, "PreviousDosages");
							break;

					}
			}
	}
	void AddRow(Transform _child, string listName)
	{
		//foreach item in the list we need to create a gameobject with the text from the list
		switch (listName)
		{
			case "Complications":
				for (int i = 0; i < patientList.Find(o => o.fullName == selectedPatient).complications.Count; i++)
				{
					GameObject newRow = Instantiate(patientInfoPrefab, _child.transform);
					newRow.transform.GetChild(0).GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).complications[i];
					patientInfoListToRemove.Add(newRow);
				}
				break;
			case "Allergies":
				for (int i = 0; i < patientList.Find(o => o.fullName == selectedPatient).allergies.Count; i++)
				{
					GameObject newRow = Instantiate(patientInfoPrefab, _child.transform);
					newRow.transform.GetChild(0).GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).allergies[i];
					patientInfoListToRemove.Add(newRow);
				}
				break;
			case "CurrentMedicine":
				for (int i = 0; i < patientList.Find(o => o.fullName == selectedPatient).currentMedicines.Count; i++)
				{
					GameObject newRow = Instantiate(patientInfoPrefab, _child.transform);
					newRow.transform.GetChild(0).GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).currentMedicines[i];
					patientInfoListToRemove.Add(newRow);
				}
				break;
			case "Prescriptions":
				for (int i = 0; i < patientList.Find(o => o.fullName == selectedPatient).prescriptions.Count; i++)
				{
					GameObject newRow = Instantiate(patientInfoPrefab, _child.transform);
					newRow.transform.GetChild(0).GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).prescriptions[i];
					patientInfoListToRemove.Add(newRow);
				}
				break;
			case "PreviousDosages":
				for (int i = 0; i < patientList.Find(o => o.fullName == selectedPatient).previousDosages.Count; i++)
				{
					GameObject newRow = Instantiate(patientInfoPrefab, _child.transform);
					newRow.transform.GetChild(0).GetComponent<Text>().text = patientList.Find(o => o.fullName == selectedPatient).previousDosages[i];
					patientInfoListToRemove.Add(newRow);
				}
				break;
		}
	



	}
}
