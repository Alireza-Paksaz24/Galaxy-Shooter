using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if (transform.position.y >= 5.9f)
        {
            Destroy(this.gameObject);
            if (this.transform.parent != null)
                Destroy(transform.parent.gameObject);
        }
    }
}
