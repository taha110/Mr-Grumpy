using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

	// Use this for initialization

	public AudioClip  clickSound, singleJumpSound;
	public AudioClip coinHitSound;
	public AudioClip StarsSound; 
	public AudioClip coinCounting; 

	public AudioClip g_atk_miss_Sound;
	public AudioClip g_die_Sound;
	public AudioClip g_jump_Sound;
	public AudioClip g_atk_Sound;

	public static SoundController Static ;
	public AudioSource[]  audioSources;
	void Start ()
	{
		Static = this;
	}
	
	// Update is called once per frame

	//for single Jump
	float lastTime ;
	public void PlaySingleJumpSound ()
	{
		if (Time.timeSinceLevelLoad - lastTime < 0.2f)
			return;
						
					 
		lastTime = Time.timeSinceLevelLoad;	
		swithAudioSources (singleJumpSound);
	}
	 
	//---------------------------------

	public void PlayClickSound ()
	{
		 
		swithAudioSources (clickSound);
	}

	public void Play_atk_miss_Sound ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (g_atk_miss_Sound);
	}
	 
	public void Play_die_Sound ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (g_die_Sound);
	}
	public void Play_atk_Sound ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (g_atk_Sound);
	}
	public void playcoinCounting ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (coinCounting);
	}

	public void playCoinHit ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (coinHitSound);
	}

	public void playStarsSound ()
	{
		
		GetComponent<AudioSource> ().PlayOneShot (StarsSound);
	}
	

	 
	 


	void swithAudioSources (AudioClip clip)
	{
		if (audioSources [0].isPlaying) {
			audioSources [1].PlayOneShot (clip);
		} else
			audioSources [0].PlayOneShot (clip);

	}
}
