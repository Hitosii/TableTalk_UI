using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_move : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(0, 0, -0.2f);
    }
}
