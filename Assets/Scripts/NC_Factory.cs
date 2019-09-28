﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_Factory : MonoBehaviour
{
    public GameObject NcPrefab;

    private void Start() {
        //二秒間隔で生成
        //InvokeRepeating("ncInstantiate", 1.0f, 2.0f);
        //起動時に一回のみ生成
        ncInstantiate();
    }
    private void Update() {
        
    }
    void ncInstantiate() {
        Instantiate(NcPrefab, new Vector3(Random.Range(-2f,4f), Random.Range(0f, 5f), -0.1f), transform.rotation);
    }
}
