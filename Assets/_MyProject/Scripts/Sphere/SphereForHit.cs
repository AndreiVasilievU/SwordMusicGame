using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereForHit : MonoBehaviour

{
    [SerializeField] private Image image;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject brokenSpherePrefab;
    
    public SphereConfig sphereConfig;
    private MeshRenderer sphereRenderer;
    
    private void Start()
    {
        sphereRenderer = GetComponent<MeshRenderer>();
        sphereRenderer.material = materials[0];
        
        image.sprite = sphereConfig.DirectionHitImage;
        image.transform.rotation = sphereConfig.RotationHitImage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ReadyToHit")
        {
            sphereRenderer.material = materials[1];
        }

        if (other.gameObject.tag == "Sword")
        {
            ScoreCounter.ChangeScoreCounter(50);
            AudioManager.Instance.OnPlaySound(1);
            gameObject.SetActive(false);
            Instantiate(brokenSpherePrefab, transform.position, sphereConfig.RotationBrokenSphere);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ReadyToHit")
        {
            ScoreCounter.GetDamage(50);
            AudioManager.Instance.OnPlaySound(0);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        sphereRenderer.material = materials[0];
    }
}
