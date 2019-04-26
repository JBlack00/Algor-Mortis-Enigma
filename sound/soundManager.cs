 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public soundHolder soundHolderscript;

    [SerializeField]
    private AudioSource AudioController;
    [SerializeField]
    private string soundName;
	[SerializeField]
    private int soundArray;

    // Use this for initialization
    void Start()
    {
		if (soundHolderscript == null) {
			soundHolderscript = GameObject.Find ("SoundManager").GetComponent<soundHolder> ();
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SearchName(string newName)
    {
		for (int i = 0; i < soundHolderscript.audioVoiceClips.Length; i++)
        {
			Debug.Log(soundHolderscript.audioVoiceClips[i].name);
			if (soundHolderscript.audioVoiceClips[i].name == (newName))
            {
                soundArray = i;
            }
        }
    }
    public void playNewSound()
    {
        SearchName(soundName);
		AudioController.clip = soundHolderscript.audioVoiceClips[soundArray] as AudioClip;
		AudioController.Play ();
    }
}