using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerInfo : MonoBehaviour {
    public UserStatusCtrl user;
    public Text pos;
    public Text exp;
    public Text sp;
    public Text money;
    public Text clear;

    private int val;

    void Update() {
        val = user.status;
        pos.text = "POSITION : " + user.rank[val];
        exp.text = "EXPERIENCE : " + user.totalExp + " / " + user.exp[val];
        sp.text = "SKILL POINT : " + user.SP;
        money.text = "MONEY : " + user.totalMoney;
        clear.text = "Clear : " + user.clearMission[0];
    }
}
