using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private GameObject table;
    private GameObject nounCard;
    private GameObject noun;
    private GameObject cardCase;
    private GameObject border;
    private GameObject picture;
    private GameObject link;
    private GameObject smallBut;
    private GameObject infoTextObj;
    private GameObject touchObj;
    private GameObject setScreen;
    private GameObject settingTitle;
    private GameObject setCardTemp;

    //NCのタップ状況(0=通常時,1=通常時にタップされた時,2=拡大時にタップされた時)
    private int touchStatus = 0;
    //オブジェクトタップ状況(Link連続タップ制限用)
    private int tCount = 0;
    //カードテンプレート番号(1:normal,2:leaf) 
    private int cardTempCount = 0;

    private TextMesh ncText;
    private Transform ccTrans;
    private Transform borderTrans;
    private Transform nounTrans;
    //※名詞情報
    private string nounText;
    //本文情報
    private string iText;

    //以下簡易プロパティ

    //主要データプロパティ
    public string NounText {
        get {
            return nounText;
        }
        set {
            if (value != null) {
                this.nounText = value;
            }
        }

    }
    public string IText {
        get {
            return iText;
        }
        set {
            if (value != null) {
                this.iText = value;
            }
        }

    }
    //GameObjectプロパティ
    public GameObject Table {
        get {
            return table;
        }
        set {
            if (value != null) {
                this.table = value;
            }
        }
    }
    

    public GameObject NC {
        get {
            return nounCard;
        }
        set {
            if (value != null) {
                this.nounCard = value;
            }
        }
    }
    public GameObject Noun {
        get {
            return noun;
        }
        set {
            if (value != null) {
                this.noun = value;
            }
        }
    }
    public GameObject CardCase {
        get {
            return cardCase;
        }
        set {
            if (value != null) {
                this.cardCase = value;
            }
        }
    }
    public GameObject Border {
        get {
            return border;
        }
        set {
            if (value != null) {
                this.border = value;
            }
        }
    }
    public GameObject Picture {
        get {
            return picture;
        }
        set {
            if (value != null) {
                this.picture = value;
            }
        }
    }
    
    public GameObject Link {
        get {
            return link;
        }
        set {
            if (value != null) {
                this.link = value;
            }
        }
    }
    public GameObject SmallBut {
        get {
            return smallBut;
        }
        set {
            if (value != null) {
                this.smallBut = value;
            }
        }
    }
    public GameObject InfoTextObj {
        get {
            return infoTextObj;
        }
        set {
            if (value != null) {
                this.infoTextObj = value;
            }
        }
    }
    public GameObject TouchObj {
        get {
            return touchObj;
        }
        set {
            if (value != null) {
                this.touchObj = value;
            }
        }
    }
    public GameObject SetScreen {
        get {
            return setScreen;
        }
        set {
            if (value != null) {
                this.setScreen = value;
            }
        }
    }
    public GameObject SettingTitle {
        get {
            return settingTitle;
        }
        set {
            if (value != null) {
                this.settingTitle = value;
            }
        }
    }
    public GameObject SetCardTemp {
        get {
            return setCardTemp;
        }
        set {
            if (value != null) {
                this.setCardTemp = value;
            }
        }
    }
    //GameObject以外プロパティ
    public int TouchStatus {
        get {
            return touchStatus;
        }
        set {
            this.touchStatus = value;
        }
    }
    public int TCount {
        get {
            return tCount;
        }
        set {
            this.tCount = value;
        }
    }
    public TextMesh NcText {
        get {
            return ncText;
        }
        set {
            if (value != null) {
                this.ncText = value;
            }
        }
    }
    public Transform CcTrans {
        get {
            return ccTrans;
        }
        set {
            if (value != null) {
                this.ccTrans = value;
            }
        }
    }
    public Transform BorderTrans {
        get {
            return borderTrans;
        }
        set {
            if (value != null) {
                this.borderTrans = value;
            }
        }
    }
    public Transform NounTrans {
        get {
            return nounTrans;
        }
        set {
            if (value != null) {
                this.nounTrans = value;
            }
        }
    }
    public int CardTempCount {
        get {
            return cardTempCount;
        }
        set {
                this.cardTempCount = value;
        }

    }


}
