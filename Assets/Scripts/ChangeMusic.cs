using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour {

    public Dropdown Selection;
    public AudioSource Music;
	// Update is called once per frame

	void Update () {
        if (Selection.value == 0)
            Music.clip = Resources.Load<AudioClip>("bensound-acousticbreeze");
        else if (Selection.value == 1)
            Music.clip = Resources.Load<AudioClip>("bensound-anewbeginning");
        else if (Selection.value == 2)
            Music.clip = Resources.Load<AudioClip>("bensound-creativeminds");
        else if (Selection.value == 3)
            Music.clip = Resources.Load<AudioClip>("bensound-goinghigher");
        else if (Selection.value == 4)
            Music.clip = Resources.Load<AudioClip>("bensound-jazzyfrenchy");
        else if (Selection.value == 5)
            Music.clip = Resources.Load<AudioClip>("bensound-memories");
        else if (Selection.value == 6)
            Music.clip = Resources.Load<AudioClip>("bensound-tenderness");
        else
            Music.clip = Resources.Load<AudioClip>("bensound-ukulele");

        if(!Music.isPlaying)
            Music.Play();
    }
}
