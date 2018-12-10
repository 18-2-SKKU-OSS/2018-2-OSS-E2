using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum StageState
{
    PLAY,PAUSE,END
};

public class StageManager : MonoBehaviour {
    //Managers. Edited
    public MissionManager[] MissionManager;

    //normal
    StageState stageState = StageState.PLAY;
    public static bool isStageEnd = false;
    public static bool isStageClear = false;
    int numOfMisson = 3;
    public static int numOfClearMisson = 0;

    //Timer
    float currentTime = 0f;
    public float limitTime = 600f;
    public Text timer;

    //Pause
    public GameObject pauseCanvas;
    public Text[] missionName;
    public Text[] missionAccomplishment;
    public GameObject player;
    Vector3 tmpPosition = new Vector3(0, 0, 0);

    //End
    public GameObject failCanvas;
    public GameObject clearCanvas;

    private void Start()
    {
	//Need Mission name for each Mission Manager!
        for(int i = 0; i < MissionManager.Length; i++)
            missionName[i].text = MissionManager[i].MissionName.text;
        StartCoroutine("Timer");

    }

    private void Update()
    {
        //PLAY
        if(stageState== StageState.PLAY)
        {
            pauseCanvas.SetActive(false);
            StartCoroutine(TimerUI());
		
            numOfClearMisson = 0;
            for(int i = 0; i < MissionManager.Length; i++)
                if (MissionManager[i].isMissionClear) numOfClearMisson++;

            if (numOfClearMisson >= numOfMisson) isStageEnd = true;
            if (currentTime >= limitTime) isStageEnd = true;
        }
        //PAUSE
        else if(stageState == StageState.PAUSE)
        {
            pauseCanvas.SetActive(true);

            for (int i = 0; i < MissionManager.Length; i++)
                missionAccomplishment[i].text = MissionManager[i].GetAccomplishment().ToString("N2") + "%";
        }
        //END
        else if (stageState == StageState.END)
        {
            if (numOfClearMisson <= 0)
            {
                isStageClear = false;
                player.transform.position = new Vector3(100, 100, -100);
                failCanvas.SetActive(true);
                StartCoroutine(LeaveStage());
            }
            else
            {
                isStageClear = true;
                player.transform.position = new Vector3(-100, 100, -100);
                clearCanvas.SetActive(true);
                StartCoroutine(LeaveStage());
            }
        }

        //Change State
        if (isStageEnd)
        {
            stageState = StageState.END;
            StopCoroutine("Timer");
        }
        //PlayAndPause
    }

    IEnumerator Timer()
    {
        while (currentTime <= limitTime)
        {
            yield return new WaitForSeconds(0.01f);
            currentTime += 0.01f;
        }
    }

    IEnumerator TimerUI()
    {
        if (currentTime <= limitTime)
        {
            timer.text = currentTime.ToString("N2") + "s / " + limitTime + "s";
        }
        else
        {
            timer.text = limitTime + "s / " + limitTime + "s";
        }
        yield return null;
    }

    public void PlayAndPause()
    {
        if (stageState == StageState.PLAY)
        {
            tmpPosition = player.transform.position;

            stageState = StageState.PAUSE;
            StopCoroutine("Timer");

            player.transform.position = new Vector3(100, 100, 100);
        }
        else if (stageState == StageState.PAUSE)
        {
            stageState = StageState.PLAY;
            StartCoroutine("Timer");

            player.transform.position = tmpPosition;
        }
    }

    IEnumerator LeaveStage()
    {
        yield return new WaitForSeconds(3f);
        StageMoveManager.ComeBackMenu();
        SceneManager.UnloadScene("Stage_01");
        //SceneManager.LoadScene("URGS_ver0.0.0");
    }
}
