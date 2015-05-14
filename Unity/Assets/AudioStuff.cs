using UnityEngine;
using System.Collections;

public class AudioStuff : MonoBehaviour {
	AudioSource fxSound;
	public AudioClip partyMusic;
	public AudioClip canalMusic;
	public AudioClip editorMusic;
	public AudioClip mansionMusic;
	public AudioClip parkMusic;
	string currentLevel;
	string previousLevel;
	// Use this for initialization
	void Start () {
		currentLevel = "";
		previousLevel = "";
		fxSound = GetComponent<AudioSource>();
		fxSound.clip = partyMusic;
		fxSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		previousLevel = currentLevel;
		currentLevel = TestManager.currentLevel;

		if(previousLevel != currentLevel)
		{
			if(fxSound.isPlaying){
				fxSound.Stop();
			}
			if(currentLevel.Contains("Party"))
			{
				fxSound.clip = partyMusic;
				fxSound.Play();
			}
			else if(currentLevel.Contains("Canal"))
			{
				fxSound.clip = canalMusic;
				fxSound.Play();
			}
			else if(currentLevel.Contains("Editor"))
			{
				fxSound.clip = editorMusic;
				fxSound.Play();
			}
			else if(currentLevel.Contains("Mansion"))
			{
				fxSound.clip = mansionMusic;
				fxSound.Play();
			}
			else if(currentLevel.Contains("Park"))
			{
				fxSound.clip = parkMusic;
				fxSound.Play();
			}
		}
	}
}
