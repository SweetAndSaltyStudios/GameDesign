using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour {

    public Transform balcony;

    private void OnTriggerEnter(Collider other) {
        var character = other.gameObject.GetComponent<Character>();
        if(character != null) {
            if(character.PlayerHasFoundKnife()) {
                var cc = character.GetComponent<CharacterController>();

                cc.enabled = false;
                other.transform.position = balcony.position;
                cc.enabled = true;
                print("koodissa ollaan" + other.name);
                //crb.MovePosition(balcony.position);
               //other.gameObject.GetComponent<CharacterController>().Move(balcony.position - other.transform.position);

                //crb.MovePosition(balcony.position);
                //crb.useGravity = false;
                //character.gameObject.transform.position = balcony.transform.position;
                //crb.isKinematic = false;
                //crb.useGravity = true;
            }
        }
    }
}
