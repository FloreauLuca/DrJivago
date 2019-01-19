﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-(MapManager.Instance.Speed*Time.deltaTime), transform.position.z);

        if (transform.position.y <= -25)
        {
            Destroy(gameObject);
        }
    }
}
