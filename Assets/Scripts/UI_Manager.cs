using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _scoreTMpro;

    [SerializeField] private GameObject _gameOver;

    [SerializeField] private GameObject _resetText;

    [SerializeField] private GameObject _livesUI;

    [SerializeField] private Sprite[] _livesSprites;

    private bool _isGameOver = false;
    

    private void Update()
    {
        if (Input.GetKey(KeyCode.R) && _gameOver)
        {
            SceneManager.LoadScene("Scenes/Game");
        }
    }

    public void UpdateScore(int score)
    {
        _scoreTMpro.text = string.Format("Score: {0}", score);
    }

    public void GameOver()
    {
        StartCoroutine(GameOverRoutin());
        _resetText.SetActive(true);
        _isGameOver = true;
    }

    public void UpdateLives(int lives)
    {
        _livesUI.GetComponent<Image>().sprite = _livesSprites[lives];
    }

    IEnumerator GameOverRoutin()
    {
        while (true)
        {
            _gameOver.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}
