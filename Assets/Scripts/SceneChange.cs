using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public void SceneChangeMain()
    {
        SceneManager.LoadScene("URGS_ver0.0.0");
    }

	public void SceneChange1()
    {
        SceneManager.LoadScene("Stage_01");
    }
}
