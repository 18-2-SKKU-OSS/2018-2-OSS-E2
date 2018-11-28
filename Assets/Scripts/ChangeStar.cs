using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStar : MonoBehaviour {

    public UserStatusCtrl user;
    public Image[] star = new Image [3];
    public int numComplete;
    int i = 0;
    
	void Update () {
        numComplete = user.clearMission[0];
        for (i = 0; i < numComplete; i++) {
            star[i].sprite = Resources.Load<Sprite>("yellow star");
        }
        
	}
}
