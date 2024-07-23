using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnHit : MonoBehaviour
{
    public bool checkHit = false;
    public bool isPressed;

    public KeyCode keyToPress;

    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(isPressed)
            {
                checkHit = true;
                gameObject.SetActive(false);

                //GameManager.instance.arrowHit();

                if(Mathf.Abs( transform.position.y) > 0.25)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else if (Mathf.Abs( transform.position.y) > 0.05f)
                {
                    Debug.Log("Great");
                    GameManager.instance.GreatHit();
                    Instantiate(greatEffect, transform.position, greatEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }

                checkHit = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            isPressed = false;

            if (!checkHit)
            {
                GameManager.instance.arrowMiss();
                Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            }
        }
    }
}
