using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(2.0f, 10.0f);
        var randomY = Random.Range(-7.9f, 7.9f);
        this.transform.position = new Vector3(randomY, 7.5f, -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (this.transform.position.y < -4.7f)
            Start();
    }
    
    //colider handler
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var player = other.transform.GetComponent<Player>();
            player.Damage();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser")
            Destroy(this.gameObject);
    }
}
