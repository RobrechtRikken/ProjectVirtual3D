using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GenerateXMLOnStart : MonoBehaviour {
    [SerializeField]
    public Canvas ParentCanvas;
    public GameObject PatientUIPrefab;

    protected MedicalAppData medi = new MedicalAppData();
    private const string XMLFILE = "medidata.xml";

    //TODO: patient, cabinet, cabinetdrawer
    
    // Use this for initialization
    void Awake ()
    {
        //Write XML
		//Add Patients
        medi.mPatients.Add(new Patient(1, "Stijn", "Getteman", 26, 64, Sex.male, PatientType.adult, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" },
			new List<string>() { "Value 1", "Value 2" }, new List<string>() { "Value 1", "Value 2" }));

		medi.mPatients.Add(new Patient(2, "Robin", "Rikken", 22, 75, Sex.male, PatientType.adult, new List<string>() { "Value 3", "Value 4" },
			new List<string>() { "Value 3", "Value 4" }, new List<string>() { "Value 3", "Value 4" },
			new List<string>() { "Value 3", "Value 4" }, new List<string>() { "Value 3", "Value 4" }));

		medi.mPatients.Add(new Patient(3, "Anne", "Mertens", 38, 70, Sex.female, PatientType.pregnant, new List<string>() { "Value 5", "Value 6" },
			new List<string>() { "Value 5", "Value 6" }, new List<string>() { "Value 5", "Value 6" },
			new List<string>() { "Value 5", "Value 6" }, new List<string>() { "Value 5", "Value 6" }));

		medi.mPatients.Add(new Patient(4, "Sandra", "Claessens", 15, 40, Sex.female, PatientType.child, new List<string>() { "Value 7", "Value 8" },
			new List<string>() { "Value 7", "Value 8" }, new List<string>() { "Value 7", "Value 8" },
			new List<string>() { "Value 7", "Value 8" }, new List<string>() { "Value 7", "Value 8" }));


		//Add VANAS Drawers
		CabinetDrawer cd = new CabinetDrawer();
        cd.mID = 0;
        cd.mIsLocked = true;  

		//Add Medicines

      //  medi.mCabinets.Add(new Cabinet());



        MedicalAppData.WriteToFile(ref medi, XMLFILE);

        //Load XML
		//We will use this instance manager to load all the data to it's respective managers
		MedicalAppDataManager.instance.LoadAppData(readXml(XMLFILE));
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private MedicalAppData readXml(string xmlFilePath)
    {
        MedicalAppData loaded;
        bool succes = MedicalAppData.ReadFromFile(xmlFilePath, out loaded);
        Debug.Log(succes);

        return loaded;
    }
}
