using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        var randomY = Random.Range(-7.9f, 7.9f);
        this.transform.position = new Vector3(randomY,7.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (this.transform.position.y < -4.7f)
            Start();
    }
}
