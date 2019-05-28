using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFalling : MonoBehaviour
{

    public GameObject audioObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
