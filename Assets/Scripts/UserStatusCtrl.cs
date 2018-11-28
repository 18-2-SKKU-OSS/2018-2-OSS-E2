using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UserStatusCtrl : MonoBehaviour {

    //*/StageManager stageManager;

    // 0: "인턴", 1: "계약직", 2: "사원", 3: "주임", 4: "대리", 5: "과장", 6: "차장", 7: "부장", 8: "수석 부장", 9: "임원"

    public string[] rank = { "인턴", "계약직", "사원", "주임", "대리", "과장", "차장", "부장", "수석 부장", "임원" };
    public int[] exp = { 0, 200, 600, 3000, 18000, 120000, 200000, 200000, 200000, 200000 };

    [Serializable]
    public class PlayerData : IDisposable
    {
        public int totalMoney, totalExp;
        public int status;
        // public string name;
        public int SP;
        public int SkillStatus;
        public string[] rank = { "인턴", "계약직", "사원", "주임", "대리", "과장", "차장", "부장", "수석 부장", "임원" };
        public int[] salary = { 7530, 8700, 10000, 16000, 23000, 35000, 57000, 90000, 140000 };
        public int[] exp = { 0, 200, 600, 3000, 18000, 120000, 200000, 200000, 200000, 200000 };
        public int[] expLimit = { 50, 120, 360, 1200, 5500, 35000, 50000, 50000, 50000, 50000 };
        public int[] clearMission = new int[9];

        /* Using statement 사용을 위해 IDisposable interface 사용*/
        #region IDisposable Support
        private bool disposedValue = false; // 중복 호출을 검색하려면

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
                }

                // TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.

                disposedValue = true;
            }
        }

        // TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
        // ~PlayerData() {
        //   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
        //   Dispose(false);
        // }

        // 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
            Dispose(true);
            // TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

    public int totalMoney, totalExp;
    public int status;                                                         // status를 index로 판단하고 이후 코드를 작성함(태우)
    public bool isCleared;
    public int DEFAULT_EXP = 10, DEFAULT_MONEY = 1000;                         // (Rank에 관계없는) 스테이지 클리어 기본 제공 값
    public int achievement = 0;                                                     // 스테이지 달성도에 따라서 %를 가지고 더 줄이거나 늘릴수 있을지도?
    public int SP, SkillStatus;
    public int[] clearMission = new int[9];

    // public string name;// 2018/08/26 기준 아직 필요없는 feature
    //public Text txt;
    // Use this for initialization
    void Start () {
        isCleared = false;
        //txt.gameObject.SetActive(false);
        LoadData();

        //*/stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update () {

        /* <상태 업데이트>
         * 스테이지 클리어->totalExp, totalMoney 증가 / salary 만큼 totalMoney 증가 
         * totalExp 증가->exp[] 비교 후 status 증가 혹은 X
         */
        if (!isCleared)
        {
            if (Input.GetKey(KeyCode.Alpha1))// 달성도 변경
            {
                if (achievement < 3)
                {
                    achievement++;//달성도, 별 세개 까지?
                    Debug.Log("현재 달성도: " + achievement);
                }
                else
                {
                    isCleared = true; //별세개면 끝나야지
                }
            }
            if (Input.GetKey(KeyCode.Alpha2))//기본 보상 변경(상위스테이지에서는 기본 보상이 높아야지)
            {
                DEFAULT_EXP += 10;
                DEFAULT_MONEY += 1000;
            }
        }
        // status를 index로 판단하고 이후 코드를 작성함(태우)

        else if (isCleared)
        {
            using (var temp = new PlayerData())
            {
                /* EXP */

                //totalExp += (DEFAULT_EXP + temp.expLimit[status]); (태우 코드)
                totalExp += DEFAULT_EXP * achievement < temp.expLimit[status] ? DEFAULT_EXP * achievement : temp.expLimit[status]; //지우누나가 원하는거 이거아님?


                // Level UP
                if (totalExp >= temp.exp[status])
                {
                    totalExp -= temp.exp[status];
                    status++;
                    SP += 3;
                }

                /* MONEY */
                totalMoney += (DEFAULT_MONEY * achievement + temp.salary[status]);// 레벨업후의 보상을 받는거임 아니면 레벨업전의 보상을 받는거임 이건 애들한테 물어봐서 결정해야할듯

                SaveData();
                //txt.gameObject.SetActive(true);
                //txt.text = "Game Clear!\n\nScore: " + achievement + "\nCurrent Rank: " + temp.rank[status] + "\nCurrent Exp: " + totalExp +"/"+temp.exp[status] + "\nCurrent Money: " 
                //    + totalMoney;
            }
            gameObject.SetActive(false);
        }
        
        if (StageManager.isStageClear || StageManager.isStageEnd)
        {
            clearMission[0] = StageManager.numOfClearMisson; // 어떤 스테이지 넘버인지 알 수 있어야 함.
            SaveData();
            LoadData();
        }

        /* <상태 저장>
         * "Save" 는 스테이지가 끝나는 순간;
         * "Load" 는 게임이 시작되는 순간과 스테이지가 끝나는 순간;
         */
    }

    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        //Application.persistentDatapath는 Debug.Log()에 치면 경로 알아낼 수 있음.

        PlayerData data = new PlayerData();

        data.totalMoney = totalMoney;
        data.totalExp = totalExp;
        data.status = status;
        data.SP = SP;
        data.SkillStatus = SkillStatus;
        data.clearMission = clearMission;
        // data.name = name;

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.OpenOrCreate);

        if (file != null && file.Length > 0)
        {
            PlayerData data = (PlayerData)bf.Deserialize(file);

            totalMoney = data.totalMoney;
            totalExp = data.totalExp;
            status = data.status;
            SP = data.SP;
            SkillStatus = data.SkillStatus;
            clearMission = data.clearMission;
            // name = data.name;
            
        }
        file.Close();
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Data"))//자료처리 관련 레이어 Data로 잡아둠
        {
            if (collision.gameObject.tag == "Save")//이부분 태그로 세이브 로드 찾으면 보기 좋지 않을까
            {
                Debug.Log("Save랑 충돌");
                SaveData();
            }
            else if (collision.gameObject.tag == "Load")
            {
                Debug.Log("Load랑 충돌");
                LoadData();
            }
            else if (collision.gameObject.tag == "Finish")//게임 끝내기
            {
                Debug.Log("게임을 끝낸다.");
                isCleared = true;
            }
        }  
    }
    */
    public void pushSkillButton(int needSP)
    {
        SP -= needSP;
        Debug.Log("SP" + needSP + "만큼 소모함");
    }

    public void ChangeSkillStatus(int skillNum)
    {
        if((SkillStatus & (1 << skillNum)) == 0)
            SkillStatus |= (1 << skillNum);
    }

    public bool isPrev(int prevSkillNum)
    {
        return (SkillStatus & (1 << prevSkillNum)) != 0;
    }
    //IEnumerator 
}
