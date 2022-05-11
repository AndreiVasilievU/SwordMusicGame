using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Screens : MonoBehaviour
{
    [SerializeField] private Image mainPanel;
    [SerializeField] private Button[] mainButtons;
    [SerializeField] private Image choseTypeGamePanel;

    [SerializeField] private Button[] handButtons;
    [SerializeField] private Image goToGamePanel;

    [SerializeField] private Button playButton;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image endGamePanel;
    [SerializeField] private GameObject gameCanvas;
    private bool inGame;

    private void Start()
    {
        endGamePanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inGame == true)
        {
            mainPanel.rectTransform.localPosition = Vector3.zero;
            gameManager.DeactivateAll();
            inGame = false;
            
            foreach (var VARIABLE in mainButtons)
            {
                VARIABLE.interactable = true;
                VARIABLE.image.DOColor(new Color(1, 1, 1f), 0.8f);
            }
        }
    }

    public void OnNewGameButton()
    {
        mainPanel.rectTransform.DOLocalMove(new Vector3(-660, 0, 0), 0.8f);
        foreach (var VARIABLE in mainButtons)
        {
            VARIABLE.interactable = false;
            VARIABLE.image.DOColor(new Color(0.4f, 0.3f, 0.3f), 0.8f);
        }
        
        foreach (var VARIABLE in handButtons)
        {
            VARIABLE.interactable = true;
            VARIABLE.image.DOColor(new Color(1f, 1f, 1f), 0.8f);
        }

        choseTypeGamePanel.rectTransform.DOLocalMove(new Vector3(0, 0, 0), 0.8f);
        AudioManager.Instance.OnPlaySound(2);
    }

    public void OnBackButton()
    {
        UpdateAllMenu();
        endGamePanel.gameObject.SetActive(false);
        gameManager.DeactivateAll();
        AudioManager.Instance.OnPlaySound(2);
    }

    public void OnHandButton(int numberButton)
    {
        if (numberButton == 0)
        {
            gameManager.numberConfigPlaying = 0;
            handButtons[1].image.DOColor(new Color(0.4f, 0.3f, 0.3f), 0.8f);
            foreach (var VARIABLE in handButtons)
            {
                VARIABLE.interactable = false;
            }
        }
        else if (numberButton == 1)
        {
            gameManager.numberConfigPlaying = 1;
            handButtons[0].image.DOColor(new Color(0.4f, 0.3f, 0.3f), 0.8f);
            foreach (var VARIABLE in handButtons)
            {
                VARIABLE.interactable = false;
            }
        }

        goToGamePanel.rectTransform.DOLocalMove(new Vector3(660, 0, 0), 0.8f);
        AudioManager.Instance.OnPlaySound(2);
    }

    public void OnPlayButton()
    {
        inGame = true;
        mainPanel.rectTransform.DOLocalMove(new Vector3(-660, 1080, 0), 0.8f);
        choseTypeGamePanel.rectTransform.DOLocalMove(new Vector3(0, 1080, 0), 0.8f);
        goToGamePanel.rectTransform.DOLocalMove(new Vector3(660, 1080, 0), 0.8f);
        AudioManager.Instance.OnPlaySound(2);
    }

    public void OnRepeatButton()
    {
        OnPlayButton();
        gameManager.timeLine.SetActive(true);
        gameCanvas.SetActive(true);
        endGamePanel.gameObject.SetActive(false);
        AudioManager.Instance.OnPlaySound(2);
    }

    public void EndGame()
    {
        gameCanvas.SetActive(false);
        gameManager.timeLine.SetActive(false);
        endGamePanel.gameObject.SetActive(true);
        inGame = false;
    }

    private void UpdateAllMenu()
    {
        mainPanel.rectTransform.DOLocalMove(new Vector3(0, 0, 0), 0.8f);
        foreach (var VARIABLE in mainButtons)
        {
            VARIABLE.interactable = true;
            VARIABLE.image.DOColor(new Color(1f, 1f, 1f), 0.8f);
        }
        
        foreach (var VARIABLE in handButtons)
        {
            VARIABLE.interactable = true;
            VARIABLE.image.DOColor(new Color(1f, 1f, 1f), 0.8f);
        }

        choseTypeGamePanel.rectTransform.DOLocalMove(new Vector3(0, 1080, 0), 0.8f);
        goToGamePanel.rectTransform.DOLocalMove(new Vector3(660, 1080, 0), 0.8f);
    }
}