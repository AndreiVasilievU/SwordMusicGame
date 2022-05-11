using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Image damageImage;
    [SerializeField] private Text scoreTextEndGamePanel;
    
    static int score = 0;

    private static Action changeScore;
    private static Action setDamage;

    private void OnEnable()
    {
        changeScore += UpdateScore;
        setDamage += SetDamage;
    }

    public static void ChangeScoreCounter(int addScore)
    {
        score += addScore;
        changeScore?.Invoke();
    }

    public static void GetDamage(int removeScore)
    {
        score -= removeScore;
        setDamage?.Invoke();
    }

    public void SetDamage()
    {
        damageImage.color = Color.red;
        damageImage.DOColor(new Color(1f, 1f, 1f, 0f), 0.3f);
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    private void OnDisable()
    {
        scoreTextEndGamePanel.text = score.ToString();
        score = 0;
        changeScore?.Invoke();
        changeScore -= UpdateScore;
        setDamage -= SetDamage;
    }
}
