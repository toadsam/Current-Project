using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    public AudioManager audioManager;
    public UIManager uiManager;
    public GameManager gameManager;

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundName)
    {
        audioManager.PlaySound(soundName);
    }

    public void UpdateScore(int score)
    {
        uiManager.UpdateScore(score);
    }

    public void GetScore()
    {
        gameManager.GetSocore();
    }
}
