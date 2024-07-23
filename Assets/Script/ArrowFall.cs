using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFall : MonoBehaviour
{

    public float musicBeat;

    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        musicBeat /= 60f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
           /* if (Input.anyKeyDown)
            {
                hasStarted = true;
            }  */
        }
        else
        {
            transform.position -= new Vector3(0f, musicBeat * Time.deltaTime, 0f);
        }
    }
}
