using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _scoreTMpro;

    public void UpdateScore(int score)
    {
        _scoreTMpro.text = string.Format("Score: {0}", score);
    }
}
