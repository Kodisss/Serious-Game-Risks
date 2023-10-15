using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPlaying = false;

    public int score = 0;

    public float timeTaken = 0f;

    public string[] epiList = new string[7];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            if (!isPlaying)
            {
                isPlaying = true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}