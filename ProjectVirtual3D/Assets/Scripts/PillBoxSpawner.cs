using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBoxSpawner : MonoBehaviour {

	public GameObject pillToSpawn;
	public string spawnName = "PillSpawn";
	public GameObject spawnLocation;
	// Use this for initialization
	void Start () 
	{
		foreach (Transform pillSpawner in transform) 
		{
			if (pillSpawner.name == spawnName) 
			{
				spawnLocation = pillSpawner.gameObject;
			}
		}
	}

	public void SpawnPill()
	{
		GameObject newPill = Instantiate (pillToSpawn, spawnLocation.transform.position, Quaternion.identity);
	}
}
