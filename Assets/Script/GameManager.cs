using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource playMusic;
    public bool hasStartPlaying;

    public ArrowFall arrowFall;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
    }

    public void arrowMiss()
    {
        Debug.Log("miss");
    }

}
