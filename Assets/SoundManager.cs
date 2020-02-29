using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour {
	public static SoundManager instance = null;     //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
	public int vo;
	public AudioSource efxSource, bgmSource;
	public AudioClip[] bgmList;
	void Awake (){
		//Check if there is already an instance of SoundManager
		if (instance == null)
			//if not, set it to this.
			instance = this;
		//If instance already exists:
		else if (instance != this)
			//Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
			Destroy (gameObject);
		
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
	}
	public void PlaySingle(AudioClip clip)
	{
		efxSource.PlayOneShot(clip);
    }
	public void RandomizeSfx (params AudioClip[] clips)
	{
		int randomIndex = Random.Range(0, clips.Length);
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		efxSource.pitch = randomPitch;
		efxSource.PlayOneShot(clips[randomIndex]);
		efxSource.pitch = 1;
	}
	public void PlayBGM(int i){
		bgmSource.clip = bgmList[i];
		StartCoroutine(fadeIn());
	}
	public void StopBGM(){
		StartCoroutine(fadeOut());
	}
	private IEnumerator fadeIn(){
		bgmSource.Play();
		bgmSource.volume = 0;
		for(int i = 0; i <= vo; i++){
			bgmSource.volume = i * 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
	}
	private IEnumerator fadeOut(){
		bgmSource.volume = vo * 0.01f;
		for(int i = vo; i >= 0; i--){
			bgmSource.volume = i * 0.01f;
			yield return new WaitForSeconds(0.01f);
		}
		bgmSource.Stop();
	}
}