using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSurvey : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    float distance = 100; //飛ばす&表示するRayの長さ
    float duration = 60;   //表示期間(秒)

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();    
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //カメラ上でタップした場所の位置情報と方向をrayに格納
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            //タップしたオブジェクトをTouchObjに格納
            mm.TouchObj = hit2d.collider.gameObject;

            //Raycast可視化(デバッグ用)※3Dモード下でのみ可視
            //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

                //Debug.Log(mm.TouchStatus);
                //Debug.Log(mm.TouchObj);

                //タップ状況に応じて、touchStatus加算
                if (mm.TouchObj.tag == "Noun") {
                    mm.TouchStatus = 1;
                } else if (mm.TouchObj.tag == "SmallBut") {
                    mm.TouchStatus = 2;
                }

                //Link以外にタップするとOpenLink連続呼び出し制限解除
                if (mm.TouchObj.tag != "Link") {
                    mm.TCount = 0;
                }

            

        }
    }
}
