using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenSphere : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,2f);
    }
}
