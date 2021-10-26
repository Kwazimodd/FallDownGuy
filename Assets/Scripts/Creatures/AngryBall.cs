using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AngryBall : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private float attackTime;
    private bool isAttacking;
    [SerializeField] private int speed;
    [SerializeField] private Transform target;
    [SerializeField] private float attackRange;
    [SerializeField] private bool canDoDamage;
    
    public bool CanDoDamage
    {
        get => canDoDamage;
        set => canDoDamage = value;
    }
    public float AttackRange
    {
        get => attackRange;
        set => attackRange = value;
    }
    public Transform Target
    {
        get => target;
        set => target = value;
    }
    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }

    public float AttackTime
    {
        get => attackTime;
        set => attackTime = value;
    }
    public Animator Animator => this.animator;

    private IState currentState;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new StaticState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage(int damage)
    {
        health -= damage;
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(this);
    }

    public void MoveTo(Vector2 direction)
    {
        rigidbody2D.velocity = direction * speed;
    }
}
