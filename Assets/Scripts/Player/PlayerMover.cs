using System;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _movenmentSpeed =2f;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _input;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _input = new Vector2(UnityEngine.Input.GetAxisRaw("Horizontal"), UnityEngine.Input.GetAxisRaw("Vertical")); 

        if (_input.sqrMagnitude > 1f)
            _input.Normalize();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position+_input*_movenmentSpeed*Time.deltaTime);
    }
}
