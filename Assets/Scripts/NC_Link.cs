using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Link : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    //とりあえずinspectorからURL指定可能に
    public string URL;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    void Start()
    {
        mm.Link = GameObject.FindWithTag("Link");
    }

    void Update()
    {   //拡大後かつOpenURL連続呼び出し未制限なら
        if ((mm.TouchStatus==1)&&(mm.TCount==0)) {
            mm.Link.GetComponent<TextMesh>().text = "URL:" + URL;
            if (mm.TouchObj.tag == "Link") {
                Application.OpenURL(URL);
                //OpenURL連続呼び出し制限
                mm.TCount += 1;
            }
            
        }
    }

}
