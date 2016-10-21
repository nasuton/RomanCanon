﻿using UnityEngine;
using System.Collections;

public class DefaultGunController : MonoBehaviour
{
    [SerializeField]
    protected GameObject bullet = null;

    [SerializeField, Tooltip("BulletSpeed")]
    protected float speed = 0.1f;

    [SerializeField, Tooltip("1発撃った後の待機時間")]
    protected float waitTimeOfShot = 0.05f;

   
}