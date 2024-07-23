using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ArrowFall arrowFall;
    public AudioSource playMusic;

    private int currentScore;
    private int currentMultiplier;
    private int multiplierTracker;
    public int[] multiplierThresholds;

    private bool hasStartPlaying;

    public static GameManager Instance { get; private set; }

    public Text scoreText;
    public Text multiplierText;

    public int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            scoreText.text = "Score: " + currentScore;
        }
    }

    public int CurrentMultiplier
    {
        get => currentMultiplier;
        set
        {
            currentMultiplier = value;
            multiplierText.text = "Multiplier: x" + currentMultiplier;
        }
    }

    private void Awake()
    {
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

    void Start()
    {
        CurrentMultiplier = 1;
        CurrentScore = 0;
    }

    void Update()
    {
        if (!hasStartPlaying && Input.anyKeyDown)
        {
            hasStartPlaying = true;
            arrowFall.hasStarted = true;
            playMusic.Play();
        }
    }

    public void ArrowHit()
    {
        Debug.Log("hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                CurrentMultiplier++;
            }
        }
    }

    public void ArrowMiss()
    {
        Debug.Log("miss");

        CurrentMultiplier = 1;
        multiplierTracker = 0;
    }
}
