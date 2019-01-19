using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }


    [SerializeField] private GameObject[] mapPrefab;
    [SerializeField] private float mapSize;

    private GameObject currentWall;
    private GameObject nextWall;


    public static MapManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        nextWall = mapPrefab[Random.Range(0, mapPrefab.Length)];
        currentWall = Instantiate(nextWall, transform);
    }
    
    void Update()
    {

        if (currentWall.transform.position.y <= transform.position.y - mapSize)
        {
            currentWall = Instantiate(nextWall, new Vector2(currentWall.transform.position.x, currentWall.transform.position.y + mapSize - speed*Time.deltaTime), Quaternion.identity, transform);
            nextWall = mapPrefab[Random.Range(0, mapPrefab.Length)];
        }
    }
    
}
