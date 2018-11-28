using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    public Slider Volume;
    public AudioSource Music;

    private void Update() {
        Music.volume = Volume.value;
    }
}
