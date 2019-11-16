﻿using System;
using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Animator _playerAnim;
    private SpriteRenderer _playerSpriteImage;

    private float _movePlayerHorizontal;
    private float _movePlayerVertical;
    private Vector2 _movement;

    [SerializeField] private float speed;

    private static readonly int XMove = Animator.StringToHash("xMove");
    private static readonly int YMove = Animator.StringToHash("yMove");

    private void Awake()
    {
        _rigidBody2D = (Rigidbody2D) GetComponent(typeof(Rigidbody2D));
        _playerAnim = (Animator) GetComponent(typeof(Animator));
        _playerSpriteImage = (SpriteRenderer) GetComponent(typeof(SpriteRenderer));
    }

    private void Update()
    {
        _movePlayerHorizontal = Input.GetAxisRaw("Horizontal");
        _movePlayerVertical = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(_movePlayerHorizontal, _movePlayerVertical);
        _rigidBody2D.velocity = _movement * speed;

        if (!Mathf.Approximately(_movePlayerVertical, 0))
        {
            _playerAnim.SetBool(XMove, false);
            _playerSpriteImage.flipX = false;
            if (_movePlayerVertical > 0)
            {
                _playerAnim.SetInteger(YMove, 1);
            }
            else if (_movePlayerVertical < 0)
            {
                _playerAnim.SetInteger(YMove, -1);
            }
        }
        else
        {
            _playerAnim.SetInteger(YMove, 0);
            if (_movePlayerHorizontal > 0)
            {
                _playerAnim.SetBool(XMove, true);
                _playerSpriteImage.flipX = false;
            }
            else if (_movePlayerHorizontal < 0)
            {
                _playerAnim.SetBool(XMove, true);
                _playerSpriteImage.flipX = true;
            }
            else
            {
                _playerAnim.SetBool(XMove, false);
            }
        }
    }
}