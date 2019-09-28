using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_move : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    Rigidbody2D ncRigid;
    float timig=0;
    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
        InvokeRepeating("Turn", 1.0f, 5.0f);
        InvokeRepeating("Move", 0f, 1.0f);
    }
    void Start(){
        mm.NC = GameObject.FindWithTag("NC");
        ncRigid = mm.NC.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
          
    }
    void Turn() {
        ncRigid.AddTorque(40f);
    }
    void Move() {
        float rx = Random.Range(1.0f, -1.0f);
        float ry = Random.Range(1.0f, -1.0f);
        Vector2 ncDirec = new Vector2(rx * 30, ry * 30);
        ncRigid.AddForce(ncDirec);
    }
}
