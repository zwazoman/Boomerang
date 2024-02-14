using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreJ1;
    [SerializeField]
    private TextMeshProUGUI scoreJ2;
    [SerializeField]
    private TextMeshProUGUI scoreJ3;
    [SerializeField]
    private TextMeshProUGUI scoreJ4;
    private int score1;
    private int score2;
    private int score3;
    private int score4;
    [SerializeField]
    private GameObject panelVictory;

    private void Awake()
    {
        score1 = 0; 
        score2 = 0;
        score3 = 0;
        score4 = 0;
        scoreJ1.text = ("Score: " +  score1);
        scoreJ2.text = ("Score: " + score2);
        scoreJ3.text = ("Score: " + score3);
        scoreJ4.text = ("Score: " + score4);
    }

    private void Update()
    {
        if (score1 == 5 && score2 == 5 && score3 == 5 && score4 == 5)
        {
            Time.timeScale = 0;
            panelVictory.SetActive(true);
        }
    }
}
