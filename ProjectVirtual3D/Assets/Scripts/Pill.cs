using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pill : MonoBehaviour {

	public GameObject currentCollidingObject;
	//private string medicineBottleScriptName = "MedicineBottle";
	public string containedMedicineLiquid;
	private Collider latestCollider;
	// Use this for initialization
	void Start () {

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
		SetCollisionObject (col);
		switch (col.gameObject.tag)
			{
		case "Trigger_LeftHand":
			Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftHand");
				break;
			case "Trigger_RightHand":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightHand");
				break;
			case "Trigger_LeftLowerThigh":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftLowerThigh");
				break;
			case "Trigger_RightLowerThigh":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightLowerThigh");
				break;
			case "Trigger_LeftUpperArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftUpperArm");
				break;
			case "Trigger_RightUpperArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightUpperArm");
				break;
			case "Trigger_LeftLowerArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftLowerArm");
				break;
			case "Trigger_RightLowerArm":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightLowerArm");
				break;
			case "Trigger_LeftAbdomen":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftAbdomen");
				break;
			case "Trigger_RightAbdomen":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightAbdomen");
				break;
			case "Trigger_LeftButtock":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("LeftButtock");
				break;
			case "Trigger_RightButtock":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("RightButtock");
				break;
			case "Trigger_Mouth":
				Debug.Log ("IM COLLIDING WITH THIS : " + col.gameObject.tag);
				SoundManager.instance.PlaySoundHover("Mouth");
				break;

			}

		}

	public void OnTriggerExit(Collider col)
	{
		RemoveCollisionObject ();
		switch (col.gameObject.tag)
		{
		case "Trigger_LeftHand":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightHand":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_LeftLowerThigh":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightLowerThigh":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_LeftUpperArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightUpperArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_LeftLowerArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightLowerArm":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_LeftAbdomen":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightAbdomen":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_LeftButtock":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_RightButtock":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;
		case "Trigger_Mouth":
			Debug.Log ("IM LEAVING THIS COLLIDER : " + col.gameObject.tag);
			break;

		}
	}




	public void Administer()
	{

		//Check first if the medicine is allowed in this body part if it is we inject it
		//else we buzzz and don't inject and give feedback that it is wrong
		Debug.Log ("CURRENTLY Administering");
		if (currentCollidingObject == null) 
		{
			Debug.Log ("Can't Administer");
		} 
		else 
		{
			if (gameObject.tag == "Pill" && currentCollidingObject.gameObject.name.Contains("Mond") || currentCollidingObject.gameObject.name.Contains("Hand"))
			{
				ShowinjectionCompletionTooltip("succes");
			}
			else
			{
				ShowinjectionCompletionTooltip("wrong");
			}
		
		}
	}


	public void SetCollisionObject(Collider col)
	{
			currentCollidingObject = col.gameObject;
	}
	public void RemoveCollisionObject()
	{
		currentCollidingObject = null;
	}


	public void ShowinjectionCompletionTooltip(string _outcome)
	{
		//Depending on good or bad injection poitioning the tooltip will go green or red
		string newToolTipNameText;
		newToolTipNameText = currentCollidingObject.gameObject.name.Replace("_", " ");
		switch (_outcome)
		{
		case "succes":

			SoundManager.instance.PlaySound ("Succes");
			MedicalAppDataManager.instance.AddUserChoice ("User succesfully administered medicine  " + this.gameObject.name + " to " + newToolTipNameText);
			Destroy (this.gameObject);
				break;
			case "wrong":
			SoundManager.instance.PlaySound("Wrong");
			MedicalAppDataManager.instance.AddUserChoice("User wrongfully administered medicine  " +  this.gameObject.name + " to " + newToolTipNameText);
				break;

		}

	}
}
