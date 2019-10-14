using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;

    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }
	
	void OnGUI ()
    {
        GUISkin skin = GUI.skin;
        skin.button.normal.textColor = Color.black;
        skin.label.normal.textColor = Color.black;
        skin.button.fontSize = 20;
        skin.label.fontSize = 20;
        GUI.skin = skin;
        if (Input.GetMouseButtonDown(0))
        {
            action.Shoot(Input.mousePosition);
            Debug.Log("Input.GetMouseButtonDown response");
        }
        GUI.Label(new Rect(0, Screen.height / 16, Screen.width / 8, Screen.height / 16), "Score:" + action.GetScore().ToString());
        if (GUI.Button(new Rect(Screen.width * 3 / 8, 0, Screen.width / 4, Screen.height / 8), "Restart"))
        {
            action.ReStart();
            return;
        }
    }

    void OnMouseDown()
    {
        action.Shoot(Input.mousePosition);
    }
}
