using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour {
    public Gameobject[] lights;
    public Gameobject[] switches;

    private void Start()
    {
        //만약, 스위치와 광원이 매칭되지 않는다면 Light System 종료
        if(lights.Length != switches.Length)
            gameObject.SetActive(false);
    }
}
