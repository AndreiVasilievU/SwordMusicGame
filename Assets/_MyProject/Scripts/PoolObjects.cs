using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> sphereCreators;
    [SerializeField] private GameObject parent;
    
    public Vector3 DoDirectionMove;
    
    private void Start()
    {
        foreach (var VARIABLE in sphereCreators)
        {
            VARIABLE.SetActive(false);
        }
    }

    public void MoveSphere()
    {
        for (int i = 0; i < sphereCreators.Count; i++)
        {
            if (sphereCreators[i].activeSelf == false)
            {
                sphereCreators[i].SetActive(true);
                return;
            }
        }
    }
}
