using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float invicibilityCooldown;

    [SerializeField] private float playerSpeed;

    [SerializeField] private GameObject sprite;

    private Animator animator;

    private Rigidbody2D rigidbody2D;
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

        if (Input.GetButton("Right"))
        {
            Move(1);
        } else if (Input.GetButton("Left"))
        {
            Move(-1);
        }

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
