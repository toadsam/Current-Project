using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int score;

    private void Start()
    {
        
    } 

    public void GetSocore()
    {
        score++;
        Debug.Log(score + "������ �޾ҽ��ϴ�.");
    }
    
    
    
}
