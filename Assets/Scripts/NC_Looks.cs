using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Looks : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    public Sprite[] setSprites;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }

    void Start() {
        mm.SetCardTemp = GameObject.FindWithTag("SetCardTemp");
        mm.CardTempCount = 1;
    }

    public void SetSprites() {
        if ((Input.GetMouseButtonDown(0)) && (mm.SetCardTemp.activeSelf)) {
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
        if (mm.CardTempCount == 1) {
            mm.SetCardTemp.GetComponent<TextMesh>().text = "Normal";
            this.GetComponent<SpriteRenderer>().sprite = setSprites[0];
        } else if (mm.CardTempCount == 2) {
            mm.SetCardTemp.GetComponent<TextMesh>().text = "Leaf";
            this.GetComponent<SpriteRenderer>().sprite = setSprites[1];
        }
    }
}
