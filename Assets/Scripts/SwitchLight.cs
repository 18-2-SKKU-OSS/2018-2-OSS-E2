using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour {
    enum State { On, Off };
    private State nowState;
    public bool isTurnOnStart = true;
    
    private void Start()
    {
        if (isTurnOnStart)
        {
            nowState = State.On;
            gameObject.SetActive(true);
        }
        else
        {
            nowState = State.Off;
            gameObject.SetActive(false);
        }
    }
}
