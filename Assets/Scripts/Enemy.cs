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
        _playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
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
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _playerScript.AddScore(_speed);
            Destroy(this.gameObject);
        }
    }
    
    //When Game is Over
    public void GameOver()
    {
        _gameOver = true;
    }
}
