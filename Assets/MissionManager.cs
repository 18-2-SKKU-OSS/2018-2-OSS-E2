using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class MissionManager : MonoBehaviour {
    public bool isMissionClear;
    public Text MissionName;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract float GetAccomplishment();
}
