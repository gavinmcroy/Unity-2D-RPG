using UnityEngine;

public class Player : Entity
{
    [SerializeField] private string[] inventory;
    [SerializeField] private string[] skills;
    [SerializeField] private int money;
    private Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }
    
}
