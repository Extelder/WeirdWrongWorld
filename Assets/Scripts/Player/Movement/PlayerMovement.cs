using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidBody;
    private float _horizontalInput;
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();

        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _horizontalInput = _controls.Main.Move.ReadValue<float>();

        _rigidBody.velocity = new Vector2(_horizontalInput * _speed, _rigidBody.velocity.y);
    }
}