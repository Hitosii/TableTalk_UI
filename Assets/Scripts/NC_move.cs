using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NC_move : MonoBehaviour
{
    GameObject mmObj;
    MainManager mm;
    public Rigidbody2D ncRigid;
    GameObject CenterPoint;
    float timig=0;
    private void Awake() {
        mmObj = GameObject.FindWithTag("MainManager");
        mm = mmObj.GetComponent<MainManager>();
        CenterPoint = GameObject.FindWithTag("Center");
        InvokeRepeating("Move", 0f, 1.0f);
    }
    void Start(){
    }

    void FixedUpdate(){
        //中心を向く動作
        Vector3 diff = (CenterPoint.transform.position - ncRigid.gameObject.transform.position);
        ncRigid.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);
    }
    
    void Move() {
        float rx = Random.Range(1.0f, -1.0f);
        float ry = Random.Range(1.0f, -1.0f);
        Vector2 ncDirec = new Vector2(rx * 50, ry * 50);
        ncRigid.AddForce(ncDirec);
    }
}
