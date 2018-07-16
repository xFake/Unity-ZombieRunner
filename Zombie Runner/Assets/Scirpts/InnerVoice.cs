using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappend;
    public AudioClip areaClear;

    private AudioSource audioSource;

	void Start () {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = whatHappend;
        audioSource.Play();
	}

    public void OnFindClearArea()
    {
        audioSource.clip = areaClear;
        audioSource.Play();
        SendMessageUpwards("SelectSpot");
    }

}
