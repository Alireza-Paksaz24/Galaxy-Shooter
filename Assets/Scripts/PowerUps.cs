using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUps : MonoBehaviour
{

    private float _speed = 3.0f;

    // Start is called in first frame
    private void Start()
    {
        this.transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 7, 0);
    }

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
        if (this.tag == "PowerUp_TripleShot" && other.tag == "Player")
        {
            other.GetComponent<Player>().SetTripleShot(true);
            Destroy(this.gameObject,0.1f);   
        }
        else if (this.tag == "PowerUp_Speed" && other.tag == "Player")
        {
            other.GetComponent<Player>().SetSpeedUp(true);
            Destroy(this.gameObject,0.1f);  
        }
    }
}