using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Vector3 secondCameraPosition;

    [SerializeField] private GameObject firstSword;
    [SerializeField] private GameObject secondSword;
    [SerializeField] private GameObject firstPoolObject;
    [SerializeField] private GameObject secondPoolObject;

    [SerializeField] private Camera camera;
    [SerializeField] private GameObject signalRecieverTwo;

    [SerializeField] private GameObject gameCanvas;
    
    public GameObject timeLine;
    public int numberConfigPlaying;

    private void Start()
    {
        DeactivateAll();
    }

    public void AddTwoHandsPlaying()
    {
        timeLine.SetActive(true);
        firstSword.SetActive(true);
        firstPoolObject.SetActive(true);
        gameCanvas.SetActive(true);
        
        if (numberConfigPlaying == 1)
        {
            secondSword.SetActive(true);
            secondPoolObject.SetActive(true);
            signalRecieverTwo.SetActive(true);

            camera.transform.position = secondCameraPosition;
        }
    }

    public void DeactivateAll()
    {
        camera.transform.position = cameraPosition;
        
        timeLine.SetActive(false);
        
        firstSword.SetActive(false);
        secondSword.SetActive(false);
        
        firstPoolObject.SetActive(false);
        secondPoolObject.SetActive(false);
        
        signalRecieverTwo.SetActive(false);
        
        gameCanvas.SetActive(false);
    }
}
