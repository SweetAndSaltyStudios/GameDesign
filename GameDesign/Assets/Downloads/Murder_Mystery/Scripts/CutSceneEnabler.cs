using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnabler : MonoBehaviour {

    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            TurnOffImage();
        }
    }

    public void TurnOffImage() {
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }
}
