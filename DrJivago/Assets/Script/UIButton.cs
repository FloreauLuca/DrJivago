using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    private bool pressed = false;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;

    [SerializeField] private bool right;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            if (Input.GetButtonDown("Right"))
            {
                pressed = true;
            }

            GameManager.Instance.Player.PressedRight = pressed;
        }
        else
        {
            if (Input.GetButtonDown("Left"))
            {
                pressed = true;
            }
            GameManager.Instance.Player.PressedLeft = pressed;
        }

        if (pressed)
        {

            spriteRenderer.sprite = pressedSprite;
        }
        else
        {

            spriteRenderer.sprite = unpressedSprite;
        }

        if (Input.GetButtonUp("Left") || Input.GetButtonUp("Right"))
        {
            pressed = false;
        }
    }

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;

    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {
        pressed = false;

    }
}
