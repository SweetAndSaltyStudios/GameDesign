using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenInside : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        print("Keittiössä ollaan");
        var character = other.gameObject.GetComponent<Character>();
        if(character != null) {
            character.PlayerGoesToKitchen();
        }
    }
}
