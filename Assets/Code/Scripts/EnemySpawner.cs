using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-4f, 8f), Random.Range(0.5f, 6f), Random.Range(0f, 4f)), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
