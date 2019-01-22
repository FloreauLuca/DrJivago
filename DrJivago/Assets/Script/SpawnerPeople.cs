using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPeople : MonoBehaviour
{
    [SerializeField] private int minNbEnemy;
    [SerializeField] private int maxNbEnemy;

    [SerializeField] private float minXSpawn;
    [SerializeField] private float maxXSpawn;

    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private float diminutionTimeBetweenSpawn;

	[SerializeField] private float minimumTimeBetweenSpawn;

	private bool end = true;

    [SerializeField] private GameObject[] peoplePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Spawn()
    {
        while (end)
        {
            int nbEnemy = Random.Range(minNbEnemy, maxNbEnemy);
            yield return new WaitForSeconds(timeBetweenSpawn);
			if (timeBetweenSpawn > minimumTimeBetweenSpawn)
			{
				timeBetweenSpawn -= diminutionTimeBetweenSpawn;
			}

            for (int i = 0; i < nbEnemy; i++)
            {
                float XSpawn = Random.Range(minXSpawn, maxXSpawn);
                Instantiate(peoplePrefab[Random.Range(0, peoplePrefab.Length)], new Vector3(XSpawn, transform.position.y, 0), transform.rotation, transform);
            }
        }

    }
}
