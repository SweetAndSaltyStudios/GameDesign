using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLocked : MonoBehaviour {
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter(Collider other) {
        audioSource.PlayOneShot(audioClip);
    }
}
