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

    [SerializeField] private float peopleSpeed = 1;
    
    void Update()
    {
        
        if (playerTransform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 20);
            Debug.Log("right");
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 20);
            Debug.Log("left");

        }
        
        rigidbody2D.velocity = (transform.rotation * Vector3.up * 5) - new Vector3(0, (MapManager.Instance.Speed * Time.deltaTime * (5+peopleSpeed)));
        Debug.Log(transform.rotation * Vector3.up);
        Debug.Log(new Vector3(0, (MapManager.Instance.Speed * Time.deltaTime * (5 + peopleSpeed))));
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
