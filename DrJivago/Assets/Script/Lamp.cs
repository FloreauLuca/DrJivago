using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - (MapManager.Instance.Speed * Time.deltaTime), transform.position.z);

        if (transform.position.y <= -25)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			if (!GameManager.Instance.Player.GetInvincibility())
			{
				GameManager.Instance.Player.Hurt();
				audioSource.Play();
			}
        }
    }
}
