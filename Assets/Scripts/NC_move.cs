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
    }
    void Start(){
        mm.NC = GameObject.FindWithTag("NC");
        ncRigid = mm.NC.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
            float rx = Random.Range(1.0f, -1.0f);
            float ry = Random.Range(1.0f, -1.0f);
            Vector2 ncDirec = new Vector2(rx * 10, ry * 10);
            ncRigid.AddForce(ncDirec);
            
    }
    private void OnCollisionEnter(Collision collision) {
        ncRigid.AddTorque(1f);
    }
}
