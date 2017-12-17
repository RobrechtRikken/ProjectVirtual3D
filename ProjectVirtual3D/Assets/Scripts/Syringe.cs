using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Syringe : MonoBehaviour {

	public VRTK_ObjectTooltip syringeTooltip;
	public float syringeSize;
	public float amountInSyringe;
	public string medicineBottleTag = "MedicineBottle";
	private string medicineBottleScriptName = "MedicineBottle";
	public float errorShowTime = 5f;
	private string overflowError = "Amount too large for this syringe";
	public MedicineBottle bottleScript;
	private Collider latestCollider;
	// Use this for initialization
	void Start () {
		syringeTooltip.UpdateText (syringeSize + "ml");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision col)
	{
		Debug.Log (this.name + " is collidng with " + col.gameObject.name);
	}

	public void OnTriggerEnter(Collider col)
	{
		latestCollider = col;
		Debug.Log (this.name + " NEEDLE is collidng with " + col.gameObject.name);
		if (col.gameObject.tag == medicineBottleTag) 
		{
			Debug.Log ("Collider with the needle is a medicine bottle and selected amount will be put in the syringe");
			bottleScript = col.gameObject.GetComponent<MedicineBottle> (); //Get bottlescript from the collided bottle
			if (bottleScript.selectedAmount > (syringeSize-amountInSyringe)) {
				StopAllCoroutines ();
				StartCoroutine (SyringeOverflow ());
			}
			else 
			{
				Debug.Log ("the amount selected will fit in this syringe");

				StartCoroutine (SyringeFill ());
			}
		}
	}

	public void RemoveTooltipOnGrab()
	{
		syringeTooltip.gameObject.SetActive(false);
	}
	public void ShowTooltipOnGrab()
	{
		if (amountInSyringe == 0) {
			syringeTooltip.UpdateText (syringeSize + "ml");
		}
		else 
		{

			syringeTooltip.UpdateText (amountInSyringe + "ml");
		}
		syringeTooltip.gameObject.SetActive(true);
	}

	public IEnumerator SyringeOverflow()
	{
		syringeTooltip.UpdateText (overflowError);
		syringeTooltip.gameObject.SetActive (true);
		yield return new WaitForSeconds (errorShowTime);
		syringeTooltip.gameObject.SetActive (false);
	}

	public IEnumerator SyringeFill()
	{
		amountInSyringe += +bottleScript.selectedAmount;
		syringeTooltip.UpdateText (amountInSyringe + "ml");
		bottleScript.RemoveSelectedAmount ();
		syringeTooltip.gameObject.SetActive (true);
		yield return new WaitForSeconds (errorShowTime);
		syringeTooltip.gameObject.SetActive (false);
	}

	public void Inject()
	{
		amountInSyringe = 0;
	}
}
