using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemyPrefab = null;
    [SerializeField]
    GameObject _enemyContainer = null;

    [SerializeField]
    GameObject _tripleShotPrefab = null;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 randomPosToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, transform.position = randomPosToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5);
            
        }
    }


    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 randomPosToSpawn = new Vector3(Random.Range(-8, 8), 7, 0);
            Instantiate(_tripleShotPrefab, transform.position = randomPosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3,7));

        }
    }
    public void OnPlayerDeath() 
    {
        _stopSpawning = true;
    }
}
