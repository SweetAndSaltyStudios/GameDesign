using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoors : MonoBehaviour {
    public GameObject image2;
    public GameObject keys;
    public bool hasSeenCutScene;
    private void OnTriggerEnter(Collider other) {
        var character = other.gameObject.GetComponent<Character>();
        if(character != null) {
            if(character.PlayerHasBeenToKitchen()) {
                if(!hasSeenCutScene) {
                    image2.gameObject.SetActive(true);
                    keys.gameObject.SetActive(true);
                    hasSeenCutScene = true;
                }

            }
        }
    }
}
