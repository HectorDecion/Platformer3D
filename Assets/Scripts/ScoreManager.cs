using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager1 : MonoBehaviour
{
    public int Score = 0;
    public int currentScore = 0;
    

    public TMP_Text starText; // The TextMeshPro object to display

    float var;
    private void Start()
    {
        Score = currentScore;

    }
    private void Update()
    {
        var = PlayerPrefs.GetFloat("Score", currentScore);
        starText.text = "Score" + var;
    }
    public void sumaScore(int scoreAmount)
    {
        currentScore += scoreAmount;
        PlayerPrefs.SetFloat("Score", currentScore);

    }
}

