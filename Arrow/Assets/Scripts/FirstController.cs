using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IActionManager
{
    void Fly(GameObject ufo);
}

public interface ISceneController
{
    void LoadResources();
}

public interface IUserAction
{
    void Shoot(Vector3 pos);
    int GetScore();
    void ReStart();
}

public enum SSActionEventType : int { Started, Competeted }

public class SSDirector : System.Object
{
    private static SSDirector _instance;      
    public ISceneController CurrentScenceController { get; set; }
    public static SSDirector GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SSDirector();
        }
        return _instance;
    }
}


public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    public IActionManager action_manager;
    public UserGUI user_gui;
    public CCJudgement judgement;
    private int count;

    void Start ()
    {
        SSDirector director = SSDirector.GetInstance();     
        director.CurrentScenceController = this;            
        judgement = Singleton<CCJudgement>.Instance;
        action_manager = gameObject.AddComponent<PhysisActionManager>() as IActionManager;
        user_gui = gameObject.AddComponent<UserGUI>() as UserGUI;
        count = 0;
    }
	
	void Update ()
    {
        if(count < 20)
        count += 1;
    }

    public void LoadResources()
    {
    }
    public void Shoot(Vector3 pos)
    {
        if (count < 20) return;
        count = 0;
        Debug.Log(pos);
        Quaternion rotations = Quaternion.identity;
        rotations.eulerAngles = new Vector3(90f, 0f, 0f);
        Vector3 start_pos = new Vector3((Input.mousePosition.x - Screen.width / 2f) *0.02f, (Input.mousePosition.y - Screen.height / 2f)*0.02f, -10);
        GameObject ufo_object = Instantiate(Resources.Load<GameObject>("Prefabs/arrow"), start_pos , rotations);
        action_manager.Fly(ufo_object);
    }
    public void AddScore(int score)
    {
        judgement.Record(score);
    }
    public int GetScore()
    {
        return judgement.score;
    }
    public void ReStart()
    {
        judgement.Reset();
    }
}
