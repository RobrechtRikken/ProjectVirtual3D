using UnityEngine;
using UnityEngine.UI;
using VRTK;

namespace Assets.Scripts.VANAS_UI
{
	public class MedicineButtons : MonoBehaviour
	{
		private InputField input;
		public LoadMedicineList patientList;
		public Transform patientlistParent;

		public void ClickKey(string character)
		{
			input.text += character;
			ShowMedicine(input.text);
		}

		public void Backspace()
		{
			if (input.text.Length > 0)
			{
				input.text = input.text.Substring(0, input.text.Length - 1);
				ShowMedicine(input.text);
			}
		}

		public void Enter()
		{
			VRTK_Logger.Info("You've typed [" + input.text + "]");
			input.text = "";
		}

		private void Start()
		{
			input = GetComponentInChildren<InputField>();
		}


		public void ShowMedicine(string inputText)
		{
			//Debug.Log("Update list");


			//Transform[] allChildren = patientlistParent.transform.GetComponentsInChildren<Transform>();
			foreach (Transform child in patientlistParent)
			{

				// do whatever with child transform here
				//Debug.Log (child.name);
				if (child.transform.GetChild(0).GetComponent<Text>().text.ToUpper().Contains(inputText))
				{
					child.transform.gameObject.SetActive(true);
				}
				else {
					child.transform.gameObject.SetActive(false);
				}
			}
			Debug.Log(inputText);
		}
	}
}