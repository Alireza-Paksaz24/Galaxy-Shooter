using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //init Variables
    private int lives = 3;

    private int _speed = 12;

    private GameObject shield;
    
    private bool isTripleShotActive = false;

    private bool isShieldActive = false;
    
    private SpawnManager _spawnManager;
    
    private UI_Manager _uiManager;
    
    private float _nextFire = 0;

    private int _score = 0;

    private AudioSource _audioSource;
    
    [SerializeField] private GameObject _laser;

    [SerializeField] private float _fireRate = 0.5f;

    [SerializeField] private GameObject _tripleLaser;

    [SerializeField] private GameObject[] _engines;
    
    // Start is called before the first frame update
    void Start()
    {
        shield = this.transform.GetChild(0).gameObject;
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        _audioSource = GetComponent<AudioSource>();
        if (_spawnManager == null)
            Debug.LogError("Spwan Manager in null");
        
        if (_spawnManager == null)
            Debug.LogError("Spwan Manager in null");
        
        if (_audioSource == null)
            Debug.LogError("Audio Source in player is null");
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
            _audioSource.Play();
        }
    }
    
    //move function for players
    private void MovePlayer()
    {
        var vector = new Vector3(0, 0, 0);
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        vector.x = _speed * horizontal *Time.deltaTime;
        vector.y = _speed * vertical *Time.deltaTime;
        //Check if cube is outside of screen
        this.transform.Translate(vector);
        if (this.transform.position.x >= 9.2)
            this.transform.position = new Vector3(9.2f,transform.position.y,transform.position.z);
        else if (this.transform.position.x <= -9.5)
            this.transform.position = new Vector3(-9.5f,transform.position.y,transform.position.z);
        if (this.transform.position.y >= 5.75)
            this.transform.position = new Vector3(transform.position.x,5.75f,transform.position.z);
        else if (this.transform.position.y <= -3.8)
            this.transform.position = new Vector3(transform.position.x,-3.8f,transform.position.z);

    }
    
    
    public void Damage()
    {
        if (!isShieldActive)
        {
            --lives;
            _uiManager.UpdateLives(lives);
            if (lives == 2)
                _engines[0].SetActive(true);
            else if (lives == 1)
                _engines[1].SetActive(true);
            if (lives == 0)
            {
                _spawnManager.OnPlayerDeath();
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var i in enemies)
                {
                    i.GetComponent<Enemy>().GameOver();
                }
                GameObject.Find("UI_Manager").GetComponent<UI_Manager>().GameOver();
                Destroy(this.gameObject);
            }
        }
    }

    public void SetTripleShot(bool status)
    {
        isTripleShotActive = status;
        StartCoroutine(DisablePowerUp(0));
    }
    
    public void SetSpeedUp(bool status)
    {
        _speed = 30;
        StartCoroutine(DisablePowerUp(1));
    }

    public void SetShield(bool status)
    {
        isShieldActive = status;
        shield.SetActive(true);
        StartCoroutine(DisablePowerUp(2));
    }
    IEnumerator DisablePowerUp(short powerUpID)
    {
        yield return new WaitForSeconds(5.0f);
        if (powerUpID == 0)
            isTripleShotActive = false;
        else if (powerUpID == 1)
            _speed = 15;
        else
        {
            isShieldActive = false;
            shield.SetActive(false);
        }
    }

    public void AddScore(float point)
    {
        _score += (int)point;
        _uiManager.UpdateScore(_score);
    }
}