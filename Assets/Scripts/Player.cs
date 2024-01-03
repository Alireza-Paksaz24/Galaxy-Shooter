using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int lives = 3;

    [SerializeField] private int _speed = 15;

    [SerializeField] private GameObject _laser;

    [SerializeField] private float _fireRate = 0.5f;

    [SerializeField] private GameObject _tripleLaser;

    private bool isTripleShotActive = false;

    private SpawnManager _spawnManager;
    
    private float _nextFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
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
            if (isTripleShotActive)
                Instantiate(_tripleLaser, this.transform.position + new Vector3(-0.6881274f,-0.140737f,0.1370336f), Quaternion.identity);
            else
                Instantiate(_laser, this.transform.position + new Vector3(0, 0.81f, 0), Quaternion.identity);
        }
    }
    
    //move function for players
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
        //Check if cube is outside of screen
        this.transform.Translate(vector);
        if (this.transform.position.x >= 10.6)
            this.transform.position = new Vector3(-10,transform.position.y,transform.position.z);
        else if (this.transform.position.x <= -10)
            this.transform.position = new Vector3(10.6f,transform.position.y,transform.position.z);
        if (this.transform.position.y >= 5.75)
            this.transform.position = new Vector3(transform.position.x,5.75f,transform.position.z);
        else if (this.transform.position.y <= -3.8)
            this.transform.position = new Vector3(transform.position.x,-3.8f,transform.position.z);

    }
    
    
    public void Damage()
    {
        --lives;
        Debug.Log(lives);
        if (lives == 0)
        {
            Destroy(this.gameObject);

            _spawnManager.OnPlayerDeath();
        }
    }
}
