namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UI_Keyboard : MonoBehaviour
    {
        private InputField input;
		public LoadPatientsList patientList;
		public Transform patientlistParent;

        public void ClickKey(string character)
        {
            input.text += character;
			ShowPatient (input.text);
        }

        public void Backspace()
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
				ShowPatient (input.text);
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


		public void ShowPatient(string inputText)
		{
			//Debug.Log("Update list");


			//Transform[] allChildren = patientlistParent.transform.GetComponentsInChildren<Transform>();
			foreach (Transform child in patientlistParent)
			{

				// do whatever with child transform here
				//Debug.Log (child.name);
				if (child.transform.GetChild (0).GetComponent<Text> ().text.ToUpper().Contains(inputText)) {
					child.transform.gameObject.SetActive (true);
				} else {
					child.transform.gameObject.SetActive (false);
				}
			}
			Debug.Log (inputText);
		}
    }
}