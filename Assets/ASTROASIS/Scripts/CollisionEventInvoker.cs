using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEventInvoker : MonoBehaviour
{
    public UnityEvent OnCollision;

    private void OnCollisionEnter()
    {
        OnCollision.Invoke();
    }
}
