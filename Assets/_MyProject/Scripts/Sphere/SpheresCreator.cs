using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpheresCreator : MonoBehaviour
{
    [SerializeField] private List<GameObject> spheresPos;
    [SerializeField] private List<SphereConfig> spheresConfigs;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private float DoDurationMove;
    [SerializeField] private PoolObjects thisPool;

    public List<GameObject> spheres;
    void Awake()
    {
        transform.position = startPos;
        
        for (int i = 0; i < spheresPos.Count; i++)
        {
            var GO = Instantiate(spherePrefab, spheresPos[i].transform.position, Quaternion.identity, spheresPos[i].transform);
            GO.GetComponent<SphereForHit>().sphereConfig = spheresConfigs[i];
            spheres.Add(GO);
        }
    }

    private void OnEnable()
    {
        MoveSphere();
    }

    private void MoveSphere()
    {
        StartCoroutine(DisableSphereCreator());
        
        transform.position = startPos;

        foreach (var VARIABLE in spheres)
        {
            VARIABLE.SetActive(false);
        }

        spheres[Random.Range(0,8)].SetActive(true);
        transform.DOMove(thisPool.DoDirectionMove, DoDurationMove);
    }

    IEnumerator DisableSphereCreator()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
