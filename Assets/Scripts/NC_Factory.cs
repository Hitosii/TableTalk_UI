using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Factory : MonoBehaviour
{
    public GameObject ncPrefab;
    private void Start() {
        //二秒間隔で生成
        //InvokeRepeating("ncInstantiate", 1.0f, 2.0f);
        //起動時に一回のみ生成
    }
    
    public void ncInstantiate(string _nameText, string _infoText) {
        var _nc = Instantiate(ncPrefab, new Vector3(Random.Range(-2f,4f), Random.Range(0f, 5f), -0.1f), transform.rotation);
        _nc.transform.GetChild(0).GetComponent<TextMesh>().text = _nameText;
        _nc.transform.GetChild(6).GetComponent<TextMesh>().text = _infoText;
        _nc.GetComponent<NC_Properties>().Name = _nameText;
        _nc.GetComponent<NC_Properties>().Info = _infoText;
        //_nc.GetComponent<TextMesh>().text
    }
}
