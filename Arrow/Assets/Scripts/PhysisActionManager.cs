using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PhysisActionManager : MonoBehaviour, IActionManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fly(GameObject arrow)
    {
        if (arrow.GetComponent<Rigidbody>() == null)
        {
            arrow.AddComponent<Rigidbody>();
        }
        arrow.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
