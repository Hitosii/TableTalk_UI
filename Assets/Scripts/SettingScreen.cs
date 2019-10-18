using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScreen : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    int settingMode = 0;
    float stoper=0,time = 0;//stoper:歯車の回転制限,time:性能による動作調整用
    GameObject sct,sc;
    GameObject setGear;
    GameObject setBackground;
    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    void Start()
    {
        mm.SetScreen = GameObject.FindWithTag("SetScreen");
        mm.SettingTitle = GameObject.FindWithTag("SettingTitle");
        mm.SetCardTemp = GameObject.FindWithTag("SetCardTemp");
        sc = GameObject.FindWithTag("SettingContents");//設定タイトル内の詳細文字
        sct = GameObject.FindWithTag("SettingContentsT");//設定タイトル文字
        setGear = GameObject.FindWithTag("SettingGear");//設定画面歯車
        setBackground = GameObject.FindWithTag("SetBackground");
        s_Falser();

    }

    void Update()
    {
        time = Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) {
            settingMode = 1;//設定画面呼び出し
        }
        if (Input.GetKey(KeyCode.C)) {
            settingMode = 2;//設定画面返却
        }
        //設定画面呼び出し後、SetScreen移動
        if ((settingMode == 1)&&(mm.SetScreen.transform.position.x >=0)) {
            mm.SetScreen.transform.Translate(-30 * time, 0, 0);
        }
        //設定画面返却後、SetScreen移動、中身非表示
        if ((settingMode == 2)&&(mm.SetScreen.transform.position.x <=19)) {
            mm.SetScreen.transform.Translate(30 * time, 0, 0);
            s_Falser();
            stoper = 0;
        }
        //設定画面呼び出し完了後、中身表示、歯車回転
        if(mm.SetScreen.transform.position.x <= 0.2) {
            s_Activer();
            stoper += Time.deltaTime;
            if(stoper <=0.3f)
            setGear.transform.Rotate(0, 0, 10);
        }
    }
    //中身非アクティブ化メソッド
    void s_Falser() {
        mm.SettingTitle.SetActive(false);
        sc.SetActive(false);
        sct.SetActive(false);
        setGear.SetActive(false);
        mm.SetCardTemp.SetActive(false);
        setBackground.SetActive(false);
    }
    //中身アクティブ化メソッド
    void s_Activer() {
        mm.SettingTitle.SetActive(true);
        sc.SetActive(true);
        sct.SetActive(true);
        setGear.SetActive(true);
        mm.SetCardTemp.SetActive(true);
        setBackground.SetActive(true);
    }
}
