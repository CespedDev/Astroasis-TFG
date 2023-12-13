using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KatanaHitEvent : MonoBehaviour
{
    public UnityEvent<Transform> OnHit;

    private void OnCollisionEnter(Collision collision)
    {
        OnHit.Invoke(collision.transform);
    }
}
