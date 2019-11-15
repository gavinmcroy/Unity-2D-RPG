using System;
using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;

    private float _movePlayerHorizontal;
    private float _movePlayerVertical;
    private Vector2 _movement;

    [SerializeField] private float speed;

    private void Awake()
    {
        _rigidBody2D = (Rigidbody2D) GetComponent(typeof(Rigidbody2D));
    }

    void Update()
    {
        _movePlayerHorizontal = Input.GetAxisRaw("Horizontal");
        _movePlayerVertical = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_movePlayerHorizontal, _movePlayerVertical);
        _rigidBody2D.velocity = _movement * speed;
    }
}