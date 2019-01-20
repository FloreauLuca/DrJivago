using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float invicibilityCooldown;

    [SerializeField] private float playerSpeed;

    [SerializeField] private GameObject sprite;

    [SerializeField] private Button buttonLeft;

    private Animator animator;

    private Rigidbody2D rigidbody2D;

    private bool pressedRight;
    public bool PressedRight
    {
        get => pressedRight;
        set => pressedRight = value;
    }

    private bool pressedLeft;
    public bool PressedLeft
    {
        get => pressedLeft;
        set => pressedLeft = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Attack();
        }

        if (Input.GetButtonDown("Right"))
        {
            pressedRight = true;
        }

        if (Input.GetButtonDown("Left"))
        {
            pressedLeft = true;
        }

        if (pressedLeft && pressedRight)
        {
            Move(0);
        } else
        if (pressedRight)
        {
            Move(1);
        } else
        if (pressedLeft)
        {
            Move(-1);
        }
        else
        {
            Move(0);
        }

        pressedRight = false;
        pressedLeft = false;


    }

    public void Move(float axisHorizontal)
    {
        if (axisHorizontal > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            sprite.transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        transform.position = new Vector3(transform.position.x + (axisHorizontal * playerSpeed), transform.position.y, 0);
    }

    public void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void Hurt()
    {
        life--;
        if (life > 0)
        {
            StartCoroutine(Invicibility());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Invicibility()
    {
        //spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(invicibilityCooldown);
        //spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
