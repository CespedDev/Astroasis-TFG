using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    private bool start = false;
    private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private Transform forward;

    void Start()
    {
        StartCoroutine(delayStart());
        characterController = GetComponent<CharacterController>();

        SmoothLocomotion loco = GetComponent<SmoothLocomotion>();
        loco.MovementSpeed     = 0;
        loco.StrafeSpeed       = 4;
        loco.StrafeSprintSpeed = 4;
        loco.ForwardDirection  = forward;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            characterController.Move(Vector3.forward * speed);
        }
    }

    IEnumerator delayStart()
    {
        yield return new WaitForSeconds(2f);
        start = true;
    }
}
