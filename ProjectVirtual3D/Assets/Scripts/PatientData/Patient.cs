
using System.Collections.Generic;
//Stores data about a patient
public class Patient
{
	#region Variables

	private int patientID;
	private string firstName;
	private string fullName;
	private string lastName;
	private byte age;
	private int weight;
	private string sex;
	private List<string> complications;
	private List<string> allergies;
	private List<string> currentMedicines;
	private List<string> previousDosages;
	private List<string> prescriptions;
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
	public string Sex
	{
		get { return sex; }
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
	public Patient(int _patientID,string _firstName, string _lastName, byte _age, int _weight, string _sex, List<string> _complications, List<string> _allergies, List<string> _currentMedicines, List<string>_previousDosages, List<string> _prescriptions)
	{
		patientID = _patientID;
		firstName = _firstName;
		lastName = _lastName;
		fullName = _firstName + " " + _lastName;
		age = _age;
		weight = _weight;
		sex = _sex;
		complications = _complications;
		allergies = _allergies;
		currentMedicines = _currentMedicines;
		previousDosages = _previousDosages;
		prescriptions = _prescriptions;


	}
}
