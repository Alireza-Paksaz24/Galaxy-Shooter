using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject _enemyContainer;

    [SerializeField] private GameObject[] _powerUps;
    
    private bool _stopSpwaning = false;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnPowerUps());
    }

    //spawn enemies co-routin function
    IEnumerator SpawnEnemies()
    {
        while (!_stopSpwaning)
        {
            var spawnedEnemy = Instantiate(enemy,new Vector3(10,11,12),Quaternion.identity);
            spawnedEnemy.transform.parent = _enemyContainer.transform;
            if (Time.time > 20.0f)
            {
                var spawnedSecondEnemy = Instantiate(enemy, new Vector3(10, 11, 12), Quaternion.identity);
                spawnedSecondEnemy.transform.parent = _enemyContainer.transform;
            }

            yield return new WaitForSeconds(5.0f);
        }
    }
    
    //Spawn Triple-Shot Power up Icon
    IEnumerator SpawnPowerUps()
    {
        while (!_stopSpwaning)
        {
            yield return new WaitForSeconds(Random.Range(0,10.0f));
            var powerUpID = Random.Range(0, _powerUps.Length);
            if (!_stopSpwaning)
            {
                var spawnedPowerUp = Instantiate(_powerUps[powerUpID]);
                spawnedPowerUp.transform.parent = _enemyContainer.transform;
            }
        }
    }
    
    // on player Death method
    public void OnPlayerDeath()
    {
        _stopSpwaning = true;
    }
}
