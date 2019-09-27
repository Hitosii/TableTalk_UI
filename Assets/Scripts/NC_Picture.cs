using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Picture : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    //とりあえずの写真保存先
    public Sprite[] pictures = new Sprite[5];
    //表示したい写真の要素数
    public int picnum;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    private void Start() {
        mm.Picture = GameObject.FindWithTag("Picture");
    }
    private void Update() {
        //拡大後かつPictureがアクティブなら
        if ((mm.Picture.activeSelf)&&(mm.TouchStatus==1)) {
            //Pictureオブジェクトのspriteに指定した写真を格納(表示)
            mm.Picture.GetComponent<SpriteRenderer>().sprite = pictures[picnum];

        //縮小時Picture非アクティブ化
        } else if (mm.TouchStatus==2) {
            mm.Picture.SetActive(false);
        }
    }
}
