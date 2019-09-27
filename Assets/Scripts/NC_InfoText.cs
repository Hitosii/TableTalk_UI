using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_InfoText : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    public string iText;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    void Start()
    {
        mm.InfoTextObj = GameObject.FindWithTag("InfoText");
    }

    void Update()
    {
        mm.InfoTextObj.GetComponent<TextMesh>().text = mm.NounText + "とは…\n" +iText;
        mm.IText = iText;
    }
}
