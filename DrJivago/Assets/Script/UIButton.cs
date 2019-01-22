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
    private PlayerMovement myPlayer;

    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovement>();
    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Player.enabled)
        {
            if (right)
            {
                if (Input.GetButtonDown("Right"))
                {
                    pressed = true;
                }
                if (Input.GetButtonUp("Right"))
                {
                    pressed = false;
                }
                if (pressed)
                {
                    myPlayer.MoveRight();
                }
                else
                {
                    myPlayer.StopMoveRight();
                }
            }
            else
            {
                if (Input.GetButtonDown("Left"))
                {
                    pressed = true;
                }
                if (Input.GetButtonUp("Left"))
                {
                    pressed = false;
                }
                if (pressed)
                {
                    myPlayer.MoveLeft();
                }
                else
                {
                    myPlayer.StopMoveLeft();
                }
            }


            if (pressed)
            {

                spriteRenderer.sprite = pressedSprite;
            }
            else
            {

                spriteRenderer.sprite = unpressedSprite;
            }

            
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
