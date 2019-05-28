using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public bool knifeFound;
    public bool keysFound;
    public bool beenToKitchen;
    public bool hasCutters;

    public void PlayerFoundKeys() {
        keysFound = true;
    }

    public bool PlayerHasFoundKeys() {
        return keysFound;
    }

    public void PlayerGoesToKitchen() {
        beenToKitchen = true;
    }

    public bool PlayerHasBeenToKitchen() {
        return beenToKitchen;
    }

    public void PlayerFoundCutters() {
        hasCutters = true;
    }

    public bool PlayerHasFoundCutters() {
        return hasCutters;
    }

    public void PlayerFoundKnife() {
        knifeFound = true;
    }

    public bool PlayerHasFoundKnife() {
        return knifeFound;
    }
}
