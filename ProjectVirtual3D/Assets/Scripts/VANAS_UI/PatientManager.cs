using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientManager : MonoBehaviour {

	public static PatientManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private string selectedPatient = "";
	public GameObject patientUI, medicineUI;

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

	void Start()
	{
	
	}

	

	//Update is called every frame.
	void Update()
	{

	}


	public void SetSelectedPatient()
	{
		StartCoroutine(SetPatientCo());
	}

	public void SetSelectedMedicine()
	{
		StartCoroutine(UnlockDrawer());
	}

	public IEnumerator SetPatientCo()
	{
		Debug.Log("SELECT PATIENT");
		yield return new WaitForSeconds(1f);
		//set patient name here and load the patient info
		patientUI.SetActive(false);
		medicineUI.SetActive(true);
	}

	public IEnumerator UnlockDrawer()
	{
		//if no drawer unlocked we wait for x seconds, then we unlock the drawer with the given medicine
		//if drawer is already unlocked return

		Debug.Log("Unlock Drawer");
		yield return new WaitForSeconds(1f);
		//code to unlock drawer
	}
}
