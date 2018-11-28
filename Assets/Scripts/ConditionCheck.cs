using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionCheck : MonoBehaviour {
    //public bool isReady = false;
    public int preC;
    public int skillNum;
    public ConditionCheck preCC;
    public UserStatusCtrl player;
    public int requiredSP;
    public Button button;

    public void setReady() {
        //if(!preCC || preCC.isReady) {
        if((preC == 0 || player.isPrev(preC)) && !player.isPrev(skillNum)) { 
            if(player.SP >= requiredSP) {
                //isReady = true;
                player.pushSkillButton(requiredSP);
                player.ChangeSkillStatus(skillNum);
                button.GetComponent<Image>().color = Color.white;
                Debug.Log("READY");
            }
        }
        else
        {  
            Debug.Log(preC);
            Debug.Log(player.isPrev(preC));
            Debug.Log(player.isPrev(skillNum));
            Debug.Log(player.SkillStatus);
            Debug.Log("구입 불가");
        }
    }
}
