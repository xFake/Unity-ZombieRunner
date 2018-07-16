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
        print(name + " OnFindClearArea");
        audioSource.clip = areaClear;
        audioSource.Play();

        Invoke("CallHeli", areaClear.length + 1);
    }

    public void CallHeli() {
        SendMessageUpwards("OnMakeInitialHeliCall");
        SendMessageUpwards("DropFlare");
    }
}
