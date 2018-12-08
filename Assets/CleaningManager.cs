﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CleaningManager : MissionManager
{
    public int needTouch = 10;
    public int achieveDust = 20;
    static public int currentDust = 0;
    GameObject[] dusts;
    GameObject[] spiderWebs;

    // Use this for initialization
    void Start()
    {
        isMissionClear = false;
        MissionName.text = "Clean Dusts and Webs";
        dusts = GameObject.FindGameObjectsWithTag("Dust");
        spiderWebs = GameObject.FindGameObjectsWithTag("SpiderWeb");
        achieveDust = dusts.Length + spiderWebs.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))//닦기스킬 강화
        {
            needTouch = 5;
        }
        if (Input.GetKey(KeyCode.Q))//닦기 장인
        {
            needTouch = 1;
        }
        if (Input.GetKey(KeyCode.R))//거미줄
        {
            GameObject[] web = GameObject.FindGameObjectsWithTag("SpiderWeb");
            foreach (GameObject obj in web)
            {
                Destroy(obj);
            }
        }
        if (currentDust > achieveDust)
        {
            isMissionClear = true;
        }

    }
    public override float GetAccomplishment()
    {
        return 100f / achieveDust * currentDust;
    }

}
