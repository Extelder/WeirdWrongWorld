using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private int _allJumps;
    [SerializeField] private PlayerGrounded _grounded;

    private Rigidbody2D _rigidBody;
    private int _currentJumps;
    private Controls _controls;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void Awake()
    {
        _controls = new Controls();

        _rigidBody = GetComponent<Rigidbody2D>();
        _currentJumps = _allJumps;
        _controls.Main.Jump.performed += context => Jump();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _grounded.Grounded.Subscribe(_ =>
        {
            if (_) _currentJumps = _allJumps;
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _controls.Disable();
        _disposable.Clear();
    }

    private void Jump()
    {
        if (_currentJumps > 0)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(transform.up * _force, ForceMode2D.Impulse);
            _currentJumps--;
        }
    }
}