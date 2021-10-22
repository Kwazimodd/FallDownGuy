using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;

    private Vector2 currentDirection = Vector2.right;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
       // Move();
        TryToAttack();
    }

    private void Attack(Vector2 direction)
    {
        GetComponentInChildren<Attacker>().Attack(direction);
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), rigidbody2D.velocity.y).normalized * speed * Time.deltaTime;
        currentDirection = rigidbody2D.velocity.x > 0 ? Vector2.right : Vector2.left;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Spikes"))
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Death");
    }

    private void TryToAttack()
    {
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
             Attack(Vector2.down);
        }

        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(currentDirection);
        }
    }
}

