using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashButton : MonoBehaviour {
    public TrashCan tc130;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    private void OnTriggerEnter(Collider other)
    {
        tc130.trash_inner = 0;
    }

}
