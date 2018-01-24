using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

	public GameObject player;
	public Vector3 playerStartPos;
	public MedicalAppDataManager mAppDataManager;
	public PatientManager pManager;
	// Use this for initialization
	void Start () {
		playerStartPos = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			player.transform.position = playerStartPos;
		}

		if (Input.GetKeyDown (KeyCode.L)) 
		{
			Destroy (mAppDataManager.gameObject);
			Destroy (pManager);
			SceneManager.LoadScene ("Sprint5");
		}
	}
}
