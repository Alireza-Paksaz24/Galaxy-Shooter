using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float _speed;
    
    [SerializeField] private float[] _rangeSpeed = new float[2];

    private Player _playerScript;

    private bool _gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player is Null");
            Destroy(this.gameObject);
        }
        _playerScript = player.GetComponent<Player>();
        _speed = Random.Range(_rangeSpeed[0], _rangeSpeed[1]);
        var randomX = Random.Range(-9.5f, 9.5f);
        this.transform.position = new Vector3(randomX, 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (this.transform.position.y < -4.7f)
        {
            if (_gameOver)
                Destroy(gameObject);
            else
                Start();
        }
    }
    
    //colider handler
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var player = other.GetComponent<Player>();
            player.Damage();
            DestroyEnemy();
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _playerScript.AddScore(_speed);
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        GetComponent<Animator>().SetTrigger("OnDestroy");
        Destroy(this.GetComponent<BoxCollider2D>());
        _speed = 0;
        Destroy(this.gameObject,2.8f);
    }

    //When Game is Over
    public void GameOver()
    {
        _gameOver = true;
    }
}
