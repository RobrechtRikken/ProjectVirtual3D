using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveInWater : MonoBehaviour {

	public string dissolvableMedicineTag = "Dissolve";
	public Material fizzyMaterial;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == dissolvableMedicineTag) 
		{
			//Medicine can be dissolved remove it from scene
			Destroy(col.gameObject);
			Debug.Log ("Change texture of water when dissolved");
			this.GetComponent<MeshRenderer> ().material = fizzyMaterial;
		}
	}
}
