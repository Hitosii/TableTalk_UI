﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_touch : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    int p=0;//Activerメソッド連続呼び出し防止用

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }


    private void Start() {
        mm.NC = GameObject.FindWithTag("NC");
        mm.CardCase = GameObject.FindWithTag("CardCase");
        mm.Noun = GameObject.FindWithTag("Noun");
        mm.Border = GameObject.FindWithTag("Border");
        mm.Picture = GameObject.FindWithTag("Picture");
        mm.Link = GameObject.FindWithTag("Link");
        mm.SmallBut = GameObject.FindWithTag("SmallBut");
        mm.InfoTextObj = GameObject.FindWithTag("InfoText");

        //コンポーネント取得
        mm.NcText = mm.Noun.GetComponent<TextMesh>();
        mm.CcTrans = mm.CardCase.transform;
        mm.BorderTrans = mm.Border.transform;
        mm.NounTrans = mm.Noun.transform;

        //読み込み時非表示
        Falser();
    }

    private void FixedUpdate() {
        float time = Time.deltaTime;
            //Nounタップ時(拡大)
            if ((mm.TouchStatus == 1)&&(mm.TouchObj.tag == "Noun")){
                //Border表示
                mm.Border.SetActive(true);
                //Picture表示
                if (p == 0) {
                    Invoke("Activer", 0.2f);
                    p = 1;
                }
                //CardCase,Border拡大
                if (mm.CcTrans.localScale.x <= 0.9f) {
                    mm.CcTrans.localScale += new Vector3(3f * time, 2 * 3f * time, 0);
                    mm.BorderTrans.localScale += new Vector3(3f * time, 2.2f * 3f * time, 0);
                    //フォントサイズ拡大
                    mm.NcText.fontSize = 130;
                }
                //Noun拡大時配置へ移動
                if (mm.NounTrans.localPosition.x >= -3f) {
                    mm.NounTrans.localPosition += new Vector3(-13.7f * time, 11f * time, 0);
                }
            //SmallButタップ時(縮小)
            } else if ((mm.TouchStatus == 2)&&(mm.TouchObj.tag == "SmallBut")) {
                p = 0;//PictureAct呼び出し可能に戻す
                //非アクティブ化
                Falser();

                //CardCase,Border縮小
                if (mm.CcTrans.localScale.x >= 0.3f) {
                    mm.CcTrans.localScale -= new Vector3(3f * time, 2 * 3f * time, 0);
                    mm.BorderTrans.localScale -= new Vector3(3f * time, 2.2f * 3f * time, 0);
                    //フォントサイズ戻す
                    mm.NcText.fontSize = 110;
                }
                //Noun通常時配置へ移動
                if (mm.NounTrans.localPosition.x <= 0f) {
                    mm.NounTrans.localPosition -= new Vector3(-13.7f * time, 11f * time, 0);
                }
                //予期しない値が入った場合、即座に縮小モードに切替
            } else if (mm.TouchStatus > 2) {
                mm.TouchStatus = 2;
            }
            //縮小終了後かつNounが通常時配置の時、touchStatusに0を代入(タップ状況を通常時に戻す)
            if ((mm.CcTrans.localScale.x <= 0.3f) && (mm.NounTrans.localPosition.x >= 0)) {
                mm.TouchStatus = 0;
            }
        
    }
    
    //アクティブ化メソッド(Invoke使用のため)
    void Activer() {
        mm.Picture.SetActive(true);
        mm.Link.SetActive(true);
        mm.SmallBut.SetActive(true);
        mm.InfoTextObj.SetActive(true);
    }
    //非アクティブ化メソッド
    void Falser() {
        mm.Border.SetActive(false);
        mm.Picture.SetActive(false);
        mm.Link.SetActive(false);
        mm.SmallBut.SetActive(false);
        mm.InfoTextObj.SetActive(false);
    }
}
