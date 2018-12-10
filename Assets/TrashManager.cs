using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TrashManager : MissionManager{
    public int emptySpeed;
    public bool autoEmpty = false;
    public bool powerEmpty = false;
    public int achieveTrash = 20;
    public int current_trash = 0;

    GameObject[] trashes;

    // Use this for initialization
    void Start()
    {
        isMissionClear = false;
        MissionName.text = "Trash Chips";
        current_trash = 0;
        trashes = GameObject.FindGameObjectsWithTag("Trash");
        achieveTrash = trashes.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))//자동비우기1
        {
            Debug.Log("skill1 activate");
            autoEmpty = true;
            emptySpeed = 3;
        }
        if (autoEmpty && Input.GetKey(KeyCode.Alpha2))//자동비우기 속업
        {
            Debug.Log("skill2 activate");
	    autoEmpty = true;
            emptySpeed = 1;
        }
        if (autoEmpty && Input.GetKey(KeyCode.Alpha3))//쓰레기 무조건 0
        {
            Debug.Log("skill3 activate");
            powerEmpty = true;
        }
        if (current_trash >= achieveTrash)
        {
            isMissionClear = true;
        }


    }
    public override float GetAccomplishment()
    {
        return 100f / achieveTrash * current_trash;
    }
}
