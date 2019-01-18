using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        playerTransform = GameManager.Instance.Player.transform;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    [SerializeField] private float peopleXSpeed = 1;
    [SerializeField] private float peopleYSpeed = 1;

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


        if (playerTransform.position.x < transform.position.x)
        {

            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -45);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45);
        }

        rigidbody2D.velocity = new Vector2((transform.rotation * Vector3.up * peopleXSpeed).x, MapManager.Instance.Speed * Time.deltaTime * -peopleYSpeed);
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
