using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public int currentScore;
    

    public TMP_Text starText; // The TextMeshPro object to display

    float var;
    private void Start()
    {
        Score = currentScore;
        PlayerPrefs.GetFloat("Score", currentScore);
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

