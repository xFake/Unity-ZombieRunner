using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {


    public AudioClip heliCallReply;
    public AudioClip heliCall;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMakeInitialHeliCall() {
        audioSource.clip = heliCall;
        audioSource.Play();
        Invoke("CallHeliReply",heliCall.length+1f);
    }

    private void CallHeliReply() {
        audioSource.clip = heliCallReply;
        audioSource.Play();
        BroadcastMessage("SendHeli");
    } 
}
