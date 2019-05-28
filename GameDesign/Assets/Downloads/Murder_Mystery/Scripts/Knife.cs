using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        var character = other.gameObject.GetComponent<Character>();
        if(character != null) {
            character.PlayerFoundKnife();
            Destroy(gameObject);
        }
    }
}
