using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHolder : MonoBehaviour {
	public Object[] audioVoiceClipsSlots;
	public Object[] audioMusicClipsSlots;
	public Object[] audioSoundEffectsClipsSlots;

	public AudioClip[] audioVoiceClips;
	public AudioClip[] audioMusicClips;
	public AudioClip[] audioSoundEffectsClips;
    // Use this for initialization
    void Start () {
		audioVoiceClips = Resources.LoadAll<AudioClip>("sound/Voice/Tut");
		audioMusicClips = Resources.LoadAll<AudioClip>("sound/Voice/Tut");
		audioVoiceClips = Resources.LoadAll<AudioClip>("sound/Voice/Tut");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
