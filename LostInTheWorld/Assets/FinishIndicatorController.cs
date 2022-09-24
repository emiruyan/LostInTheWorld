using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishIndicatorController : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}