using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnHit : MonoBehaviour
{
    public bool checkHit = false;
    public bool isPressed;

    public KeyCode keyToPress;
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

                GameManager.instance.arrowHit();
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
            }
        }
    }
}
