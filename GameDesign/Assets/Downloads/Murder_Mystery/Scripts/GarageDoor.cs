using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoor : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;
    bool doorOpened;

    private void OnTriggerEnter(Collider other) {
        var character = other.gameObject.GetComponent<Character>();
        if(character != null) {
            if(character.PlayerHasFoundKeys()) {
                // Open Door
                print("Open Door!");
                if(!doorOpened) {
                    doorOpened = true;
                    transform.LookAt(Vector3.right, Vector3.up);
                }
            } else {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
