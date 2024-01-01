using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject _enemyContainer;

    private bool _stopSpwaning = false;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //spawn enemies co-routin function
    IEnumerator SpawnEnemies()
    {
        while (!_stopSpwaning)
        {
            var spawnedEnemy = Instantiate(enemy);
            spawnedEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }
    
    // on player Death method
    public void OnPlayerDeath()
    {
        _stopSpwaning = true;
    }
}
