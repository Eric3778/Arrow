using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    private bool stop;
    private FirstController action;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
        action = SSDirector.GetInstance().CurrentScenceController as FirstController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (stop) return;
        stop = true;
        if (collision.gameObject.name == "roll5")
            action.AddScore(1);
        else if (collision.gameObject.name == "roll4")
            action.AddScore(2);
        else if (collision.gameObject.name == "roll3")
            action.AddScore(3);
        else if (collision.gameObject.name == "roll2")
            action.AddScore(4);
        else if (collision.gameObject.name == "roll1")
            action.AddScore(5);

        Destroy(this.GetComponent<Rigidbody>());
    }
}
