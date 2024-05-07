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

    private void OnEnable()
    {
        StartCoroutine(delayStart());
        characterController = GetComponent<CharacterController>();

        SmoothLocomotion loco = GetComponent<SmoothLocomotion>();
        loco.MovementSpeed = 0;
        loco.StrafeSpeed = 4;
        loco.StrafeSprintSpeed = 4;
        loco.ForwardDirection = forward;
    }
    private void OnDisable()
    {
        SmoothLocomotion loco = GetComponent<SmoothLocomotion>();
        start = false;
        loco.MovementSpeed = 1.25f;
        loco.StrafeSpeed = 1.25f;
        loco.StrafeSprintSpeed = 1.25f;
        loco.ForwardDirection = null;
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
