using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ArrowFall arrowFall;
    public AudioSource playMusic;

    public int currentScore;
    public int currentMultiplier;
    public int scorePerGood = 100;
    public int scorePerGreat = 125;
    public int scorePerPerfect = 150;
    public int multiplierTracker;
    public int[] multiplierThresholds;


    public bool hasStartPlaying;

    public static GameManager instance;

    public Text score;
    public Text multiplierScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        score.text = "Score = 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStartPlaying)
        {
            if(Input.anyKeyDown)
            {
                hasStartPlaying = true;
                arrowFall.hasStarted = true;

                playMusic.Play();
            }
        }
    }

    public void arrowHit()
    {
        Debug.Log("hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiplierScore.text = "Multiplier: x" + currentMultiplier;

        currentScore += scorePerGood * currentMultiplier;
        score.text = "Score: " + currentScore;
    }

    public void GoodHit()
    {
        currentScore += scorePerGood * currentMultiplier;
        arrowHit();
    }

    public void GreatHit()
    {
        currentScore += scorePerGreat * currentMultiplier;
        arrowHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfect * currentMultiplier;
        arrowHit();
    }

    public void arrowMiss()
    {
        Debug.Log("miss");

        currentMultiplier = 1;
        multiplierTracker = 0;

        multiplierScore.text = "Multiplier: x" + currentMultiplier;
    }

}
