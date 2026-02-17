using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    private void Awake() { 
        Instance = this;
    }

    public void AddScore(int amount) {
        score += amount;
        scoreText.text = "Skóre: " + score;
        Debug.Log(scoreText.text);
    }
}
