using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalAppDataManager : MonoBehaviour {

	// Use this for initialization
	public static MedicalAppDataManager instance = null;
	private MedicalAppData medicalAppData;

	public MedicalAppData MedicalAppData
	{
		get { return medicalAppData; }
	}

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

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadAppData(MedicalAppData _loadedData)
	{
		medicalAppData = _loadedData;
	}
}
