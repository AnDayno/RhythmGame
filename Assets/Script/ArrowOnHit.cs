using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnHit : MonoBehaviour
{
    public bool checkHit = false;
    public bool isPressed;

    public KeyCode keyToPress;

    public GameObject goodEffect, greatEffect, perfectEffect, missEffect;

    private void Update()
    {
        if (Input.GetKeyDown(keyToPress) && isPressed)
        {
            checkHit = true;
            gameObject.SetActive(false);

            Hit hit;
            if (Mathf.Abs(transform.position.y) > 0.25)
            {
                hit = new GoodHit();
                Debug.Log("Good");
            }
            else if (Mathf.Abs(transform.position.y) > 0.05f)
            {
                hit = new GreatHit();
                Debug.Log("Great");
            }
            else
            {
                hit = new PerfectHit();
                Debug.Log("Perfect");
            }

            hit.Apply(GameManager.Instance, transform.position, GetEffect(hit));
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
                Hit missHit = new MissHit();
                missHit.Apply(GameManager.Instance, transform.position, missEffect);
            }
        }
    }

    private GameObject GetEffect(Hit hit)
    {
        if (hit is GoodHit)
            return goodEffect;
        if (hit is GreatHit)
            return greatEffect;
        if (hit is PerfectHit)
            return perfectEffect;
        return null;
    }
}
