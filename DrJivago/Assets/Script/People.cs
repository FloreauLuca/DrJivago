using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject spriteAlive;
    [SerializeField] private GameObject spriteDeath;


    [SerializeField] private float peopleXSpeed = 1;
    [SerializeField] private float peopleYSpeed = 1;
    [SerializeField] private Color deathColor;

    private bool dead = false;

    [SerializeField] private AudioClip death;
    private AudioSource audioSource;

    void Start()
    {
        playerTransform = GameManager.Instance.Player.transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        /*
        if (playerTransform.position.x < transform.position.x)
        {

            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (30 * (playerTransform.position.x - transform.position.x)));
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (30 * (playerTransform.position.x - transform.position.x)));
        }*/

        if (!dead)
        {
            if (playerTransform.position.x < transform.position.x)
            {

                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -20);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 20);
            }

            rigidbody2D.velocity = new Vector2((transform.rotation * Vector3.up * peopleXSpeed).x, MapManager.Instance.Speed * Time.deltaTime * -peopleYSpeed);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (MapManager.Instance.Speed * Time.deltaTime), transform.position.z);
        }

        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        GameManager.Instance.AddScore();
        spriteAlive.GetComponent<SpriteRenderer>().color = deathColor;
        spriteAlive.GetComponent<Animator>().enabled = false;
        spriteDeath.GetComponent<SpriteRenderer>().enabled = true;
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        dead = true;
        audioSource.clip = death;
        audioSource.loop = false;
        audioSource.Play();
    }
}
