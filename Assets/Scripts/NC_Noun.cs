using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Noun : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    //とりあえずinspectorから名詞挿入可に
    public string nText;

    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
    }
    void Start()
    {
        mm.Noun = GameObject.FindWithTag("Noun");
    }
    void Update()
    {
        mm.Noun.GetComponent<TextMesh>().text = nText;
        mm.NounText = nText;
    }
}
