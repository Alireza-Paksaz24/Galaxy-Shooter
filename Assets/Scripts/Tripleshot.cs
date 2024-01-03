using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tripleshot : MonoBehaviour
{

    private float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6)
            Destroy(this.gameObject);
    }
    
    // OnTrigerEnter method. if player enter, Power up will be activated
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().SetTripleShot(true);
            Destroy(this.gameObject,0.1f);
        }
        
    }
}
