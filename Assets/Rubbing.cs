using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbing : MonoBehaviour {
    public int taking = 0;
    public CleaningManager CS;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        if (taking > CS.needTouch)
        {
            CleaningManager.currentDust++;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cleaner")
        {
            taking++;
        }

    }

}
