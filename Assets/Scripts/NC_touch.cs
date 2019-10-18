using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NC_touch : MonoBehaviour {
    GameObject mmObj;
    MainManager mm;
    public GameObject nounCard;
    public TextMesh nounText;
    public TextMesh infoText;
    public SpriteRenderer picture;
    public TextMesh linkText;
    public SpriteRenderer cardCase;
    public GameObject border;
    public GameObject smallButton;

    int p = 0;//Activerメソッド連続呼び出し防止用
    float time;
    Vector3 Cscale, Bscale;//Cardテンプレートによる拡大縮小速度
    //カードのタップ状況
    bool isOpen = false;
    bool isOnly = false;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    private void Start() {
        //読み込み時非表示
        Falser();
    }
    private void FixedUpdate() {
        time = Time.deltaTime;
        //各カードテンプレートによった拡大縮小速度の調整
        Vector3 normalBScale = new Vector3(3f * time, 6.5f * time, 0);
        Vector3 normalCScale = new Vector3(3f * time, 6f * time, 0);
        Vector3 leafBScale = new Vector3(3f * time, 6.5f * time, 0);
        Vector3 leafCScale = new Vector3(3f * time, 6f * time, 0);
        if (mm.CardTempCount == 1) {
            Cscale = normalCScale;
            Bscale = normalBScale;
        } else if (mm.CardTempCount == 2) {
            Cscale = leafCScale;
            Bscale = leafBScale;
        }
        //Nounタップ時(拡大)
        if (isOpen) {
            
            //CardCase,Border拡大
            if (cardCase.gameObject.transform.localScale.x <= 0.9f) {
                cardCase.gameObject.transform.localScale += new Vector3(Cscale.x, Cscale.y, 0);
                border.transform.localScale += new Vector3(Bscale.x, Bscale.y, 0);
                //フォントサイズ拡大,アンカー:左上
                nounText.fontSize = 130;
                nounText.anchor = TextAnchor.UpperLeft;
            }
            //Noun拡大時配置へ移動
            if (nounText.gameObject.transform.localPosition.x >= -3.7f) {
                nounText.gameObject.transform.localPosition += new Vector3(-19f * time, 14f * time, 0);
            }
        //SmallButtonタップ時(縮小)
        } else {
            
            if (cardCase.gameObject.transform.localScale.x > 0.3f) {
                cardCase.gameObject.transform.localScale -= new Vector3(Cscale.x, Cscale.y, 0);
                border.transform.localScale -= new Vector3(Bscale.x, Bscale.y, 0);
                //フォントサイズ戻す,アンカー:中央
                nounText.fontSize = 110;
                nounText.anchor = TextAnchor.MiddleCenter;
            }
            //Noun通常時配置へ移動
            if (nounText.gameObject.transform.localPosition.x < 0f) {
                nounText.gameObject.transform.localPosition -= new Vector3(-19f * time, 14f * time, 0);
            }
        }

    }
    //カードが開かれた際の処理
    public void OpenCardEvent() {
        isOpen = true;//カードが開かれた
        border.SetActive(true);
        //Picture表示
        if (p == 0) {
            Invoke("Activer", 0.2f);
            p = 1;
        }

    }
    //カードが閉じられた際の処理
    public void CloseCaedEvent() {
        isOpen = false;//カードが閉じられた
        p = 0;//PictureAct呼び出し可能に戻す
        //nounCard.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //非アクティブ化
        Falser();
    }

    //アクティブ化メソッド(Invoke使用のため)
    void Activer() {
        picture.gameObject.SetActive(true);
        linkText.gameObject.SetActive(true);
        smallButton.SetActive(true);
        infoText.gameObject.SetActive(true);
    }
    //非アクティブ化メソッド
    void Falser() {
        border.SetActive(false);
        picture.gameObject.SetActive(false);
        linkText.gameObject.SetActive(false);
        smallButton.SetActive(false);
        infoText.gameObject.SetActive(false);
    }
    public void GetCardInfomation(string getNounText,string getInfoText,string getLinkText,Sprite getPicture) {
        nounText.text = getNounText;
        infoText.text = getInfoText;
        linkText.text = getLinkText;
        picture.sprite = getPicture;
    }
}
