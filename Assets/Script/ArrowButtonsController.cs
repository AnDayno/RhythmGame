using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonsController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite arrowSprite;
    public Sprite pressedArrowSprite;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            spriteRenderer.sprite = pressedArrowSprite;
        }
        
        if (Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = arrowSprite;
        }
    }
}
