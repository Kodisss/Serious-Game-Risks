using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // make it a singleton
    public static GameManager instance;

    // game data on the player
    public bool isPlaying = false; // this is usefull if we want to implement a pause menu
    public int score = 0;
    public float timeTaken = 0f;
    public string[] epiList = new string[7];


    // singleton management
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