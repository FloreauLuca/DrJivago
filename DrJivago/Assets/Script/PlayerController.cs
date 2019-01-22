using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life;
    public int Life => life;

    
    [SerializeField] private float invicibilityCooldown;
    [SerializeField] private float shockCooldown;

    [SerializeField] private float playerSpeed;
    private bool invicibility;


    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Animator animator;
    private AudioSource audioSource;
    public AudioSource AudioSource
    {
        get => audioSource;
        set => audioSource = value;
    }

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

    [SerializeField] private AudioClip sword;
    [SerializeField] private AudioClip hurt;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Attack();
        }
    }
    /*
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

        rigidbody2D.velocity = Vector2.zero;

    }

    public void Move(float axisHorizontal)
    {
        if (axisHorizontal > 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (axisHorizontal < 0)
        {
            sprite.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
    */
    public void Attack()
    {
        animator.SetTrigger("Attack");
        audioSource.PlayOneShot(sword);
    }

    public bool Hurt()
    {
        if (!invicibility)
        {
            life--;
            UIManager.Instance.DisplayLife(life);
            if (life > 0)
            {
                StartCoroutine(Invicibility());
            }
            else
            {
                animator.enabled = false;
                MapManager.Instance.Speed = 0;
                GameManager.Instance.End();
            }

            return true;
        }

        return false;
    }

    private IEnumerator Invicibility()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        MapManager.Instance.Speed /= 2;
        invicibility = true;
        audioSource.PlayOneShot(hurt);
        yield return new WaitForSeconds(shockCooldown);
        MapManager.Instance.Speed *= 2;
        
        yield return new WaitForSeconds(invicibilityCooldown);
        invicibility = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
