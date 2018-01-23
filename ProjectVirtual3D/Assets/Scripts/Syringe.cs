using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Syringe : MonoBehaviour {

	public GameObject currentCollidingObject;
	public Color basicColor;
	public Color goodColor;
	public Color faultColor;
	public VRTK_ObjectTooltip syringeTooltip;
	public float syringeSize;
	public float amountInSyringe;
	public string medicineBottleTag = "MedicineBottle";
	//private string medicineBottleScriptName = "MedicineBottle";
	public float errorShowTime = 5f;
	private string overflowError = "Amount too large for this syringe";
	public MedicineBottle bottleScript;
	private Collider latestCollider;
	private string syringeTooltipText;
	private string injectText = "Inject ";
	private string syringeEmpty = "Syringe is empty";
	private string succesfullInjectionMessage = "Injected: ";
	// Use this for initialization
	void Start () {
		basicColor = new Color(0.18f,0.58f,0.96f);
		goodColor = new Color(0.08f,0.81f,0.18f);
		faultColor = new Color(1f,0f,0f);
		syringeTooltipText = "Capacity: " + syringeSize + "ml \n Contains : " + amountInSyringe + "ml";
		syringeTooltip.UpdateText (syringeTooltipText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision col)
	{
		//Debug.Log (this.name + " is collidng with " + col.gameObject.name);
	}

	public void OnTriggerEnter(Collider col)
	{
		switch (col.gameObject.tag)
			{
		case "Trigger_LeftHand":
			Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftHand");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightHand":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightHand");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_LeftLowerThigh":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftLowerThigh");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightLowerThigh":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightLowerThigh");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_LeftUpperArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftUpperArm");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightUpperArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightUpperArm");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_LeftLowerArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftLowerArm");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightLowerArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightLowerArm");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_LeftAbdomen":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftAbdomen");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightAbdomen":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightAbdomen");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_LeftButtock":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("LeftButtock");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_RightButtock":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("RightButtock");
				ShowInjectionToolTip (col);
				break;
			case "Trigger_Mouth":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySound("Mouth");
				ShowInjectionToolTip (col);
				break;
			case "MedicineBottle":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				Debug.Log ("Collider with the needle is a medicine bottle and selected amount will be put in the syringe");
				bottleScript = col.gameObject.GetComponent<MedicineBottle> (); //Get bottlescript from the collided bottle
				if (bottleScript.selectedAmount > (syringeSize-amountInSyringe)) 
				{
					StopAllCoroutines ();
					StartCoroutine (SyringeOverflow ());
				}
				else 
				{
					Debug.Log ("the amount selected will fit in this syringe");
				StartCoroutine (SyringeFill(col.gameObject.name));
				}
				break;

			}


		/*
		Debug.Log (this.name + " NEEDLE is collidng with " + col.gameObject.name);
		if (col.gameObject.tag == medicineBottleTag) 
		{
			Debug.Log ("Collider with the needle is a medicine bottle and selected amount will be put in the syringe");
			bottleScript = col.gameObject.GetComponent<MedicineBottle> (); //Get bottlescript from the collided bottle
			if (bottleScript.selectedAmount > (syringeSize-amountInSyringe)) 
			{
				StopAllCoroutines ();
				StartCoroutine (SyringeOverflow ());
			}
			else 
			{
				Debug.Log ("the amount selected will fit in this syringe");

				StartCoroutine (SyringeFill ());
			}
			*/
		}

	public void OnTriggerExit(Collider col)
	{
		switch (col.gameObject.tag)
		{
		case "Trigger_LeftHand":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightHand":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_LeftLowerThigh":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightLowerThigh":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_LeftUpperArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightUpperArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_LeftLowerArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightLowerArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_LeftAbdomen":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightAbdomen":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_LeftButtock":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_RightButtock":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
		case "Trigger_Mouth":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			ResetInjectionTooltip ();
			break;
			case "MedicineBottle":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;

		}


		/*
		Debug.Log (this.name + " NEEDLE is collidng with " + col.gameObject.name);
		if (col.gameObject.tag == medicineBottleTag) 
		{
			Debug.Log ("Collider with the needle is a medicine bottle and selected amount will be put in the syringe");
			bottleScript = col.gameObject.GetComponent<MedicineBottle> (); //Get bottlescript from the collided bottle
			if (bottleScript.selectedAmount > (syringeSize-amountInSyringe)) 
			{
				StopAllCoroutines ();
				StartCoroutine (SyringeOverflow ());
			}
			else 
			{
				Debug.Log ("the amount selected will fit in this syringe");

				StartCoroutine (SyringeFill ());
			}*/
	}


	public void RemoveTooltipOnGrab()
	{
		syringeTooltip.gameObject.SetActive(false);
	}
	public void ShowTooltipOnGrab()
	{		
		syringeTooltip.UpdateText (syringeTooltipText);
		syringeTooltip.gameObject.SetActive(true);
	}

	public IEnumerator SyringeOverflow()
	{
		syringeTooltip.UpdateText (overflowError);
		syringeTooltip.gameObject.SetActive (true);
		yield return new WaitForSeconds (errorShowTime);
		syringeTooltip.gameObject.SetActive (false);
	}

	public IEnumerator SyringeFill(string medicineParent)
	{
		SoundManager.instance.PlaySound("Ping");
		MedicalAppDataManager.instance.userChoices.Add("User filled syringe with a " + medicineParent + "  liquid");
		amountInSyringe += +bottleScript.selectedAmount;
		UpdateTooltip ();
		syringeTooltip.UpdateText (syringeTooltipText);
		bottleScript.RemoveSelectedAmount ();
		syringeTooltip.gameObject.SetActive (true);
		yield return new WaitForSeconds (errorShowTime);
		syringeTooltip.gameObject.SetActive (false);
		
	}

	public void Inject()
	{

		//Check first if the medicine is allowed in this body part if it is we inject it
		//else we buzzz and don't inject and give feedback that it is wrong
		Debug.Log ("CURRENTLY INJECTING");
		if (currentCollidingObject == null || amountInSyringe == 0) 
		{
			Debug.Log ("Can't inject");
		} 
		else 
		{
			if (gameObject.tag == "Syringe" && !currentCollidingObject.gameObject.name.Contains("Mond"))
			{
				amountInSyringe = 0;
				ShowinjectionCompletionTooltip("succes");
			}
			else
			{
				ShowinjectionCompletionTooltip("wrong");
			}
		
		}
	}

	public void UpdateTooltip()
	{
		syringeTooltip.containerColor = basicColor;
		syringeTooltipText = "Capacity: " + syringeSize + "ml \n Contains : " + amountInSyringe + "ml";
	}

	public void ShowInjectionToolTip(Collider col)
	{
		string newToolTipNameText;
		//If the syringe is empty show an error message that you can't inject
		if (amountInSyringe == 0) {
			currentCollidingObject = col.gameObject;
			syringeTooltip.UpdateText (syringeEmpty);
			syringeTooltip.gameObject.SetActive (true);
		} 
		else 
		{
			currentCollidingObject = col.gameObject;
			newToolTipNameText = col.gameObject.name.Replace("_", " ");
			syringeTooltip.UpdateText (injectText + newToolTipNameText + "?");
			syringeTooltip.gameObject.SetActive (true);
		}

	}

	public void ResetInjectionTooltip()
	{
		currentCollidingObject = null;
		UpdateTooltip ();
		syringeTooltip.gameObject.SetActive (false);
	}

	public void ShowinjectionCompletionTooltip(string _outcome)
	{
		//Depending on good or bad injection poitioning the tooltip will go green or red
		string newToolTipNameText;
		newToolTipNameText = currentCollidingObject.gameObject.name.Replace("_", " ");
		switch (_outcome)
		{
			case "succes":
				syringeTooltip.containerColor = goodColor;
				syringeTooltip.UpdateText(succesfullInjectionMessage + newToolTipNameText);
				SoundManager.instance.PlaySound("Succes");
				MedicalAppDataManager.instance.userChoices.Add("User succesfully injected medicine into " + newToolTipNameText);
				break;
			case "wrong":
				syringeTooltip.containerColor = faultColor;
				syringeTooltip.UpdateText("Wrong injection point");
				SoundManager.instance.PlaySound("Wrong");
				MedicalAppDataManager.instance.userChoices.Add("User wrongfully injected medicine into " + newToolTipNameText);
				break;

		}

	}
}
