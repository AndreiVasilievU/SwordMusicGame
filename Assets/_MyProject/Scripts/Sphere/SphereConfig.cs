using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SphereConfig : ScriptableObject
{
    [SerializeField] private Sprite directionHitImage;
    [SerializeField] private Quaternion rotationHitImage;
    [SerializeField] private Quaternion rotationBrokenSphere;

    public Sprite DirectionHitImage => directionHitImage;
    public Quaternion RotationHitImage => rotationHitImage;
    public Quaternion RotationBrokenSphere => rotationBrokenSphere;
}