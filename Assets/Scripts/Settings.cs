using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject tableSprites;
    GameObject mmObj;
    MainManager mm;
    public Sprite[] cardTempSprites;
    public Sprite[] backgroundSprites;
    public GameObject setBackground;
    int setBackCount = 1;
    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    void Start()
    {
        mm.SetCardTemp = GameObject.FindWithTag("SetCardTemp");
        mm.CardCase = GameObject.FindWithTag("CardCase");
        mm.CardTempCount = 1;
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)) {
            if (mm.SetCardTemp.activeSelf) {
                //テンプレート:Leaf
                if ((mm.TouchObj.tag == "SetCardTemp") && (mm.CardTempCount == 1)) {
                    mm.CardTempCount = 2;
                    Debug.Log("Leaf化");
                    //テンプレート:normal
                } else if ((mm.TouchObj.tag == "SetCardTemp") && (mm.CardTempCount == 2)) {
                    mm.CardTempCount = 1;
                    Debug.Log("normal化");
                } else if ((mm.TouchObj.tag == "SetCardTemp") && (mm.CardTempCount > 2)) {
                    mm.CardTempCount = 1;
                }
            }
            if (setBackground.activeSelf) {
                if ((mm.TouchObj.tag == "SetBackground") && (setBackCount == 1)){
                    setBackCount = 2;
                }else if((mm.TouchObj.tag == "SetBackground") && (setBackCount == 2)) {
                    setBackCount = 1;
                } else if ((mm.TouchObj.tag == "SetBackground") && (setBackCount > 2)) {
                    setBackCount = 1;
                }
            }

        }
        if (mm.CardTempCount == 1) {
            mm.SetCardTemp.GetComponent<TextMesh>().text = "Normal";
            mm.CardCase.GetComponent<SpriteRenderer>().sprite = cardTempSprites[0];
        } else if (mm.CardTempCount == 2) {
            mm.SetCardTemp.GetComponent<TextMesh>().text = "Leaf";
            mm.CardCase.GetComponent<SpriteRenderer>().sprite = cardTempSprites[1];
        }
        if (setBackCount == 1) {
            setBackground.GetComponent<TextMesh>().text = "Normal";
            tableSprites.GetComponent<SpriteRenderer>().sprite = backgroundSprites[0];
        } else if(setBackCount == 2) {
            setBackground.GetComponent<TextMesh>().text = "Wood&Stone";
            tableSprites.GetComponent<SpriteRenderer>().sprite = backgroundSprites[1];
        }
    }
}
