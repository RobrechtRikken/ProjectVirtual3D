using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MedicineBottle : MonoBehaviour {

	public float amountInBottle = 5f;
	public float selectedAmount = 0f;
	private float maxAmount;
	private float minamount = 0f;
	// Use this for initialization
	void Start () 
	{
		maxAmount = amountInBottle;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CycleAmountToUse()
	{
		//Cycle through the amount of cc you want to take out of the bottle
		Debug.Log (this.name + " is cycling through amounts");
		if (selectedAmount == maxAmount) {
			selectedAmount = minamount;
		}
		else 
		{
			selectedAmount++;
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
	}
}
