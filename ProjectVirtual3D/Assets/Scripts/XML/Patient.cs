using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System;
using System.IO;

[Serializable]
public enum PatientType
{
    adult = 1,
    child,
    pregnant,
    senior
}

public enum Sex
{
    male = 1,
    female,
    X
}


public class Patient
{
   #region Variables
	[XmlAttribute]
	public int patientID;
	public string firstName;
	public string lastName;
	public string fullName;
	public byte age;
	public Sex sex;
	public int weight;
	public PatientType patientType;
	public List<string> complications;
	public List<string> allergies;
	public List<string> currentMedicines;
	public List<string> previousDosages;
	public List<string> prescriptions;
	#endregion

	#region Properties

	public int PatientID
	{
		get { return patientID; }
	}
	public string FullName
	{
		get { return fullName; }
	}

	public string FirstName
	{
		get { return firstName; }
	}
	public string LastName
	{
		get { return lastName; }
	}
	public byte Age
	{
		get { return age; }
	}
	public int Weight
	{
		get { return weight; }
	}
	public Sex Sex
	{
		get { return sex; }
	}

	public PatientType PatientType
	{
		get { return patientType; }
	}
	public List<string> Complications
	{
		get { return complications; }
	}
	public List<string> Allergies
	{
		get { return allergies; }
	}
	public List<string> CurrentMedicines
	{
		get { return currentMedicines; }
	}
	public List<string> PreviousDosages
	{
		get { return previousDosages; }
	}
	public List<string> Prescriptions
	{
		get { return prescriptions; }
	}



	#endregion

	public Patient()
	{
		//Default constructor
	}

	public Patient(int _patientID, string _firstName, string _lastName, byte _age, int _weight, Sex _sex, PatientType _patientType, List<string> _complications, List<string> _allergies, List<string> _currentMedicines, List<string> _previousDosages, List<string> _prescriptions)
	{
		patientID = _patientID;
		firstName = _firstName;
		lastName = _lastName;
		fullName = _firstName + " " + _lastName;
		age = _age;
		weight = _weight;
		sex = _sex;
		patientType = _patientType;
		complications = _complications;
		allergies = _allergies;
		currentMedicines = _currentMedicines;
		previousDosages = _previousDosages;
		prescriptions = _prescriptions;


	}
}

