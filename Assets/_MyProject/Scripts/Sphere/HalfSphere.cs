using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSphere : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Vector3 directionImpulse;
    void Start()
    {
        rigidbody.AddForce(directionImpulse,ForceMode.Impulse);
    }
}
