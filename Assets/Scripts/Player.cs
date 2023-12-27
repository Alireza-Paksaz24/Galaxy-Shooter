using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 15;

    [SerializeField] private GameObject _Laser;

    [SerializeField] private float _fireRate = 0.5f;
    
    private float _nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireLaser();
    }
    
    //cooldown for fire laser
    private void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire += _fireRate;
            Instantiate(_Laser, this.transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
        }
    }
    
    //move function for player
    private void MovePlayer()
    {
        var vector = new Vector3(0, 0, 0);
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if (horizontal > 0.0f)
        {
            vector.x = _speed * horizontal *Time.deltaTime;
        }
        else if (horizontal < 0.0f)
        {
            vector.x = _speed * horizontal *Time.deltaTime;
        }

        if (vertical > 0.0f)
        {
            vector.y = _speed * vertical *Time.deltaTime;
        }
        else if (vertical < 0.0f)
        {
            vector.y = _speed * vertical *Time.deltaTime;
        }

        this.transform.Translate(vector);
    }
}
