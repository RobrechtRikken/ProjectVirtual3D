using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance = null;

	private const string notePath = "Sounds/";
	private AudioSource audioSource;

	private AudioClip[] assetsAudioClips;
	public List<AudioClip> listOfSounds = new List<AudioClip>();
	
// Use this for initialization
void Start () {
		audioSource = GetComponent<AudioSource>(); //set audiosource component
	}

	// Update is called once per frame
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}

		//If instance already exists and it's not this:
		else if (instance != this)
		{
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		LoadAllAudioClips();
	}

	void LoadAllAudioClips()
	{
		assetsAudioClips = Resources.LoadAll<AudioClip>(notePath);
		foreach (AudioClip clip in assetsAudioClips)
		{
			listOfSounds.Add(clip);
		}
	}

	public void PlaySound(string _soundName)
	{
		audioSource.clip = listOfSounds.Find(o => o.name == (_soundName)); //Set the audiclip to the given parameter
		audioSource.PlayOneShot(audioSource.clip);
	}

	public void PlaySoundHover(string _soundName)
	{
		audioSource.clip = listOfSounds.Find(o => o.name == (_soundName)); //Set the audiclip to the given parameter
		if (!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(audioSource.clip);
		}
		
	}
}
