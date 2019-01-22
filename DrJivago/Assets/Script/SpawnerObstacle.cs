using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObstacle : MonoBehaviour
{

    [SerializeField] private float minXSpawn;
    [SerializeField] private float maxXSpawn;

    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float diminutionTimeBetweenSpawn;

    private bool end = true;

    [SerializeField] private GameObject[] objectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while (end)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            if (timeBetweenSpawn > diminutionTimeBetweenSpawn)
            {
                timeBetweenSpawn -= diminutionTimeBetweenSpawn;
            }
            float XSpawn = Random.Range(minXSpawn, maxXSpawn);
            Instantiate(objectPrefab[Random.Range(0, objectPrefab.Length)], new Vector3(XSpawn, transform.position.y, 0), transform.rotation, transform);
        }

    }
}
