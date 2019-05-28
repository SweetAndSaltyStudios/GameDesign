using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggering : MonoBehaviour
{
    public GameObject audioObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioObject.SetActive(true);
            print(audioObject.name);
        }
    }
}
