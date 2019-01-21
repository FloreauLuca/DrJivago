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
            GameManager.Instance.Player.PressedRight = pressed;
        }
        else
        {
            GameManager.Instance.Player.PressedLeft = pressed;
        }
    }

    private void OnMouseDown()
    {
        pressed = true;
        spriteRenderer.sprite = pressedSprite;
    }

    private void OnMouseUp()
    {
        pressed = false;
        spriteRenderer.sprite = unpressedSprite;

    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {
        pressed = false;
        spriteRenderer.sprite = unpressedSprite;

    }
}
