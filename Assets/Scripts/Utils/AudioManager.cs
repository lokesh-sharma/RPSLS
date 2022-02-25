using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager>
{
	private AudioSource audioSource;
	Dictionary<string, AudioClip> clips;

	protected override void Awake()
	{
		base.Awake();
		GameObject container = new GameObject ();
		container.transform.SetParent (transform, false);
		audioSource = container.AddComponent <AudioSource> ();
		clips = new Dictionary<string, AudioClip> ();
	}

	private AudioClip GetAudioClip(string clipName)
	{
		AudioClip clip = null;
		if (!clips.TryGetValue (clipName, out clip)) {
			clip = (AudioClip) Resources.Load ("Sounds/" + clipName, typeof(AudioClip));
			clips [clipName] = clip;
		}

		return clip;
	}

    public void PlayEffect(string clipName , float vol = 1.0f)
	{
		AudioClip clip = GetAudioClip (clipName);
        audioSource.volume = vol;
		audioSource.PlayOneShot (clip);
	}
}
