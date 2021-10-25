using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Animator animator;
    private Attacker attacker;

    private List<String> collisionsList = new List<string>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        attacker = GetComponentInChildren<Attacker>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        Move();
        if (Input.GetKey(KeyCode.Space) && collisionsList.Contains("Block"))
        {
            Jump();
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            attacker.Attack(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            attacker.Attack(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            attacker.Attack(Vector2.right);
        }
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(horizontal * speed, rigidbody2D.velocity.y);
        Debug.Log(horizontal);
        animator.SetInteger("x", (int)horizontal);
    }

    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(0, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        collisionsList.Add(other.gameObject.tag);
        if (collisionsList.Contains("Spikes"))
        {
            Death();
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        collisionsList.Remove(other.gameObject.tag);
    }

    private void Death()
    {
        Debug.Log("Death");
    }
}

