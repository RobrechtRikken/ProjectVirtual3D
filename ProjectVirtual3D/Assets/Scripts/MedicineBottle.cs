using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MedicineBottle : MonoBehaviour {
	
	public float amountInBottle = 5f;
	public float selectedAmount = 0f;
	public VRTK_ObjectTooltip theTooltip;
	private float maxAmount;
	private float minamount = 0f;
	//private string selectedAmountString = "Selected amount: ";
	private float toolTipShowtime = 5f;
	private string medicineBottleText;

	// Use this for initialization
	void Start () 
	{
		maxAmount = amountInBottle;	
		medicineBottleText = "Contains: " + amountInBottle + "ml" + "\nSelected: " + selectedAmount + "ml";
		UpdateBottleTextToolTip ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CycleAmountToUse()
	{
		Debug.Log("Cycled");
		//Cycle through the amount of cc you want to take out of the bottle
		if (selectedAmount == maxAmount) 
		{
			StopAllCoroutines ();
			StartCoroutine (Showtooltip());
			selectedAmount = minamount;
			UpdateBottleTextToolTip ();
			theTooltip.UpdateText(medicineBottleText);
		}
		else 
		{
			StopAllCoroutines ();
			StartCoroutine (Showtooltip());
			selectedAmount++;
			UpdateBottleTextToolTip ();
			theTooltip.UpdateText(medicineBottleText);
		}
	}

	public void RemoveSelectedAmount()
	{
		//remove the selected amount from the bottle
		amountInBottle = amountInBottle - selectedAmount;
		//Reset the selected amount
		selectedAmount = minamount;
		//Set the maxAmount for the bottle to what is left in the bottle
		maxAmount = amountInBottle;
		UpdateBottleTextToolTip ();
	}

	public IEnumerator Showtooltip()
	{
		UpdateBottleTextToolTip ();
		theTooltip.gameObject.SetActive (true);
		yield return new WaitForSeconds (toolTipShowtime);
		theTooltip.gameObject.SetActive (false);
	}
	private void UpdateBottleTextToolTip()
	{
		medicineBottleText = "Contains: " + amountInBottle+ "ml" + "\nSelected: " + selectedAmount+"ml";
	}
}
