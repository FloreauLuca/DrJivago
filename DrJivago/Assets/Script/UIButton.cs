using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    private bool pressed;

    [SerializeField] private bool right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {

        }
        else
        {
            GameManager.Instance.Player.PressedLeft = pressed;
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
