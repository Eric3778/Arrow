using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SituationType : int { Continue, Loss }

public class CCJudgement : MonoBehaviour
{
    public int score; 

    void Start ()
    {
        score = 0;
    }

    public void Record(int roll_num)
    {
        score += roll_num;
    }

    public void Reset()
    {
        score = 0;
    }
}
