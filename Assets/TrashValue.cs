using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashValue : MonoBehaviour {
    public Slider slider;
    TrashCan tc130;

	// Use this for initialization
	void Start () {
        tc130 = GetComponent<TrashCan>();
        slider.maxValue = tc130.maxInner;
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = tc130.trash_inner;
	}
}
