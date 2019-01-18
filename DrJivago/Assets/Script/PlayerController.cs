using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private float invicibilityCooldown;

    private SpriteRenderer spriteRenderer;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Attack();
        }
    }

    private void Attack()
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
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(invicibilityCooldown);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
