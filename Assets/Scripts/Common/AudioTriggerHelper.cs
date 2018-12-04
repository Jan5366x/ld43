using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioTriggerHelper : MonoBehaviour {

	private AudioSource _audioData;

	private void Start()
	{
		_audioData = GetComponent<AudioSource>();
		_audioData.Play();
		Destroy(gameObject, _audioData.clip.length);
	}
	
	
}
